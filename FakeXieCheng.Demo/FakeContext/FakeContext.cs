using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXieCheng.Demo.Models;
using Microsoft.EntityFrameworkCore;

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
            base.OnModelCreating(modelBuilder);
        }
    }
}
