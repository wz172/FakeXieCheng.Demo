using FakeXieCheng.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Services
{
   public interface ITouristRoutRepository
    {
        public IEnumerable<TouristRout> GetTourisRouts();
        public TouristRout GetTouristRout(Guid id);
        public bool JudgeTouristRouteExist(Guid touristRouteId);
        public IEnumerable<TouristRoutPicture> GetTouristRoutesPictures(Guid touristRouteID);
        public TouristRoutPicture GetTouistRoutePicture(Guid touristRouteID, int Pid);
    }
}
