using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FakeXieCheng.Demo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FakeXieCheng.Demo.MyFakeContext
{
    public class FakeContext:DbContext
    {
        public FakeContext(DbContextOptions<FakeContext> options):base(options)
        {
        }
        public DbSet<TouristRout> TouristRout { get; set; }
        public DbSet<TouristRoutPicture> TouristRoutPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string rootPathDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string touristRoutsStr=  File.ReadAllText(Path.Combine(rootPathDir, "FakeContext/touristRouts.json"),System.Text.Encoding.UTF8);

            List<TouristRout> touristRoutsList = JsonConvert.DeserializeObject<List<TouristRout>>(touristRoutsStr);
            string picturesStr = File.ReadAllText(Path.Combine(rootPathDir, "FakeContext/picture.json"), System.Text.Encoding.UTF8);
            List<TouristRoutPicture> picturesList = JsonConvert.DeserializeObject<List<TouristRoutPicture>>(picturesStr);
         
            //数据处理
            for (int idx = 0; idx < touristRoutsList.Count; idx++)
            {
                var touristTemp = touristRoutsList[idx];
                touristTemp.ID = Guid.NewGuid();
                touristTemp.CreateTime = DateTime.Now.AddDays(idx * -1);
             
                touristTemp.TravlDays = (byte)idx;
                if (idx == 0)
                {
                    touristTemp.TripType = TripType.BackPackTour;
                    touristTemp.StratCity = DepartureCity.Beijing;
                }
                else if (idx == 1)
                {
                    touristTemp.TripType = TripType.Group;
                    touristTemp.StratCity = DepartureCity.Shanghai;
                }
                else if (idx > 5)
                {
                    touristTemp.TripType = TripType.PrivateGroup;
                    touristTemp.StratCity = DepartureCity.Shenzhen;
                }
            }
            for (int i = 0; i < picturesList.Count; i++)
            {
                picturesList[i].ID = -(i+1);
                if (touristRoutsList.Count<=i)
                {
                    picturesList[i].TouristRoutID = touristRoutsList[touristRoutsList.Count-1].ID;
                }
                else
                {
                    picturesList[i].TouristRoutID = touristRoutsList[i].ID;
                }
                
            }
            modelBuilder.Entity<TouristRout>().HasData(touristRoutsList);
            modelBuilder.Entity<TouristRoutPicture>().HasData(picturesList);

            base.OnModelCreating(modelBuilder);
        }
    }
}
