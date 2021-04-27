using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FakeXieCheng.Demo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FakeXieCheng.Demo.MyFakeContext
{
    public class FakeContext : IdentityDbContext<MyApplicationIdentity>  //:DbContext
    {
        public FakeContext(DbContextOptions<FakeContext> options) : base(options)
        {
        }
        public DbSet<TouristRout> TouristRout { get; set; }
        public DbSet<TouristRoutPicture> TouristRoutPictures { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartLineItem> CartLineItems { get; set; }

        public DbSet<UserOrder> userOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Random random = new Random();
            string rootPathDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string touristRoutsStr = File.ReadAllText(Path.Combine(rootPathDir, "FakeContext/touristRouts.json"), System.Text.Encoding.UTF8);

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
                touristTemp.Rating = random.Next(100);
            }
            for (int i = 0; i < picturesList.Count; i++)
            {
                picturesList[i].ID = -(i + 1);
                if (touristRoutsList.Count <= i)
                {
                    picturesList[i].TouristRoutID = touristRoutsList[touristRoutsList.Count - 1].ID;
                }
                else
                {
                    picturesList[i].TouristRoutID = touristRoutsList[i].ID;
                }

            }
            modelBuilder.Entity<TouristRout>().HasData(touristRoutsList);
            modelBuilder.Entity<TouristRoutPicture>().HasData(picturesList);
            //初始化用户与角色的种子数据
            //1. 更新用户和角色外键
            modelBuilder.Entity<MyApplicationIdentity>(u => u.HasMany(x => x.UserRoles).WithOne().HasForeignKey(ur => ur.UserId).IsRequired());
            //2. 添加管理员角色
            var adminRoleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "admin",
                    NormalizedName = "admin".ToUpper(),
                }
                );
            //3. 添加用户
            var adminUserId = Guid.NewGuid().ToString();
            string adminEmail = "172@qq.com";
            MyApplicationIdentity myApplicationIdentity = new MyApplicationIdentity()
            {
                Id = adminUserId,
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpper(),
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = "123456",
                PhoneNumberConfirmed = false
            };
            var ph = new PasswordHasher<MyApplicationIdentity>();
            myApplicationIdentity.PasswordHash = ph.HashPassword(myApplicationIdentity, "Fake123!");
            modelBuilder.Entity<MyApplicationIdentity>().HasData(myApplicationIdentity);
            //4. 给用户加入管理员角色
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
