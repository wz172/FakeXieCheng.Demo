using FakeXieCheng.Demo.Models;
using FakeXieCheng.Demo.RequestParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Services
{
   public interface ITouristRoutRepository
    {
        public IEnumerable<TouristRout> GetTourisRouts(TouristRouteRequestParam touristRouteParam);
        public TouristRout GetTouristRout(Guid id);
        public bool JudgeTouristRouteExist(Guid touristRouteId);
        public IEnumerable<TouristRoutPicture> GetTouristRoutesPictures(Guid touristRouteID);
        public TouristRoutPicture GetTouistRoutePicture(Guid touristRouteID, int Pid);
        public void AddTouristRoute(TouristRout rout);
        public bool Save();
        public void AddTouristRoutePicture(Guid tourisrRouteId, TouristRoutPicture picture);
    }
}
