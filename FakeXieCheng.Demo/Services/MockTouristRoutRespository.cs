using FakeXieCheng.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Services
{
    public class MockTouristRoutRespository  //:ITouristRoutRepository
    {
        private List<TouristRout> mockList;
        public MockTouristRoutRespository()
        {
            if (mockList == null)
            {
                InitMockList();
            }
        }

        public IEnumerable<TouristRout> GetTourisRouts()
        {
            return this.mockList;
        }

        public TouristRout GetTouristRout(Guid id)
        {
            return mockList.SingleOrDefault(x => x.ID == id);
        }

        private void InitMockList()
        {
            this.mockList = new List<TouristRout>();
            TouristRout touristRout = new TouristRout()
            {
                ID = Guid.NewGuid(),
                Title = "青天河",
                Description = "都是水",
                OriginalPrice = 1300,
                Features = "吃喝玩乐",
                Notes = "注意安全",
                CreateTime = DateTime.Now,
                Fees = "住宿费自己掏"
            };
            TouristRout touristRout1 = new TouristRout()
            {
                ID = Guid.NewGuid(),
                Title = "八里沟",
                Description = "没啥好玩的",
                Fees = "交通费自理",
                OriginalPrice = 1250,
                Notes = "人比较多"
            };
            this.mockList.Add(touristRout);
            this.mockList.Add(touristRout1);

            TouristRoutPicture picture = new TouristRoutPicture()
            {
                Url = "../images/1.jpg",
                Destription = "太美丽了",

            };
        }
    }
}
