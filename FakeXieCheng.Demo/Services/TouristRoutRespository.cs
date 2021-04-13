using FakeXieCheng.Demo.Models;
using FakeXieCheng.Demo.MyFakeContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Services
{
    public class TouristRoutRespository:ITouristRoutRepository
    {
        public FakeContext FakeContext { get; }
        public TouristRoutRespository(FakeContext context)
        {
            FakeContext = context;
        }

        public IEnumerable<TouristRout> GetTourisRouts()
        {
            return FakeContext.TouristRout.ToList();
        }

        public TouristRout GetTouristRout(Guid id)
        {
            return FakeContext.TouristRout
                .Where(xt => xt.ID == id)
                .FirstOrDefault();
        }
    }
}
