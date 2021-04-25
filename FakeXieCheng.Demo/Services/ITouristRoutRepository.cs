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
        public Task<IEnumerable<TouristRout>> GetTourisRoutsAsync(TouristRouteRequestParam touristRouteParam);
        public Task<TouristRout> GetTouristRoutAsync(Guid id);
        public Task <bool> JudgeTouristRouteExistAsync(Guid touristRouteId);
        public Task<IEnumerable<TouristRoutPicture>> GetTouristRoutesPicturesAsync(Guid touristRouteID);
        public  Task<TouristRoutPicture> GetTouistRoutePictureAsync(Guid touristRouteID, int Pid);
        public void AddTouristRoute(TouristRout rout);
        public  Task<bool> SaveAsync();
        public void AddTouristRoutePicture(Guid tourisrRouteId, TouristRoutPicture picture);
        public void DeleteTouristRoute(TouristRout route);
        public void DeleteTouristRoutePicture(TouristRoutPicture picture);
        public void DeleteTouristRoutes(IEnumerable<TouristRout> routes);
        public void DeleteTouristRoutePictures(IEnumerable<TouristRoutPicture> pictures);
        public Task<IEnumerable<TouristRout>> GetTourisRoutsAsync(IEnumerable<Guid> ids);
        public Task< IEnumerable<TouristRoutPicture>> GetTouristRoutesPicturesAsync(Guid touristRouteID,IEnumerable<int> ids);
        public Task<ShoppingCart> GetShoopingCartByUserIdAsync(string userId);
        public Task AddShoppingCartAsync(ShoppingCart cart);
    }
}
