using FakeXieCheng.Demo.Models;
using FakeXieCheng.Demo.MyFakeContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FakeXieCheng.Demo.Services
{
    public class TouristRoutRespository : ITouristRoutRepository
    {
        public FakeContext FakeContext { get; }
        public TouristRoutRespository(FakeContext context)
        {
            FakeContext = context;
        }

        public IEnumerable<TouristRout> GetTourisRouts()
        {
            return FakeContext.TouristRout
                .Include(xt=>xt.Pictures)
                .ToList();
        }

        public TouristRout GetTouristRout(Guid id)
        {
            return FakeContext.TouristRout
                .Where(xt => xt.ID == id)
                .Include(xt=>xt.Pictures)
                .FirstOrDefault();
        }

        public bool JudgeTouristRouteExist(Guid touristRouteId)
        {
            return FakeContext.TouristRout.Any(x => x.ID == touristRouteId);
        }

        public IEnumerable<TouristRoutPicture> GetTouristRoutesPictures(Guid touristRouteID)
        {
            return FakeContext.TouristRoutPictures.Where(x => x.TouristRoutID == touristRouteID).ToList();
        }

        public TouristRoutPicture GetTouistRoutePicture(Guid touristRouteID, int Pid)
        {
            if (!JudgeTouristRouteExist(touristRouteID))
            {
                return null;
            }
            return FakeContext.TouristRoutPictures.FirstOrDefault(p => p.ID == Pid);
        }
    }
}
