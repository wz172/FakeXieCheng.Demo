using FakeXieCheng.Demo.Models;
using FakeXieCheng.Demo.MyFakeContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FakeXieCheng.Demo.RequestParams;

namespace FakeXieCheng.Demo.Services
{
    public class TouristRoutRespository : ITouristRoutRepository
    {
        public FakeContext FakeContext { get; }
        public TouristRoutRespository(FakeContext context)
        {
            FakeContext = context;
        }

        public async Task<IEnumerable<TouristRout>> GetTourisRoutsAsync(TouristRouteRequestParam touristRouteParam)
        {
            IQueryable<TouristRout> resultQueryable = FakeContext.TouristRout
                .Include(xt => xt.Pictures);
            if (!string.IsNullOrEmpty(touristRouteParam.TitleKeyWord))
            {
                resultQueryable = resultQueryable.Where(xt => xt.Title.Contains(touristRouteParam.TitleKeyWord));
            }
            if (touristRouteParam.RatingLogicType != LogicType.Null)
            {
                switch (touristRouteParam.RatingLogicType)
                {
                    case LogicType.Null:
                        break;
                    case LogicType.LessThen:
                        resultQueryable = resultQueryable.Where(xt => xt.Rating < touristRouteParam.RatingValue);
                        break;
                    case LogicType.EqualTo:
                        resultQueryable = resultQueryable.Where(xt => xt.Rating == touristRouteParam.RatingValue);
                        break;
                    case LogicType.LargeThen:
                        resultQueryable = resultQueryable.Where(xt => xt.Rating > touristRouteParam.RatingValue);
                        break;
                    case LogicType.LessAndEqual:
                        resultQueryable = resultQueryable.Where(xt => xt.Rating <= touristRouteParam.RatingValue);
                        break;
                    case LogicType.LargeAndEqual:
                        resultQueryable = resultQueryable.Where(xt => xt.Rating >= touristRouteParam.RatingValue);
                        break;
                    default:
                        break;
                }
            }

            return await resultQueryable.ToListAsync();
        }

        public async Task<TouristRout> GetTouristRoutAsync(Guid id)
        {
            return await FakeContext.TouristRout
                .Where(xt => xt.ID == id)
                .Include(xt => xt.Pictures)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> JudgeTouristRouteExistAsync(Guid touristRouteId)
        {
            return await FakeContext.TouristRout.AnyAsync(x => x.ID == touristRouteId);
        }

        public async Task<IEnumerable<TouristRoutPicture>> GetTouristRoutesPicturesAsync(Guid touristRouteID)
        {
            return await FakeContext.TouristRoutPictures.Where(x => x.TouristRoutID == touristRouteID).ToListAsync();
        }

        public async Task<TouristRoutPicture> GetTouistRoutePictureAsync(Guid touristRouteID, int Pid)
        {
            if (!(await JudgeTouristRouteExistAsync(touristRouteID)))
            {
                return null;
            }
            return await FakeContext.TouristRoutPictures.FirstOrDefaultAsync(p => p.ID == Pid);
        }

        public void AddTouristRoute(TouristRout rout)
        {
            FakeContext.TouristRout.Add(rout);
        }

        public async Task<bool> SaveAsync()
        {
            return await FakeContext.SaveChangesAsync() > 0;
        }

        public void AddTouristRoutePicture(Guid tourisrRouteId, TouristRoutPicture picture)
        {
            if (!FakeContext.TouristRout.Any(x => x.ID == tourisrRouteId) || picture == null)
            {
                throw new ArgumentNullException(nameof(tourisrRouteId));
            }
            picture.TouristRoutID = tourisrRouteId;
            FakeContext.TouristRoutPictures.Add(picture);
        }

        public void DeleteTouristRoute(TouristRout route)
        {
            FakeContext.TouristRout.Remove(route);
        }

        public void DeleteTouristRoutePicture(TouristRoutPicture picture)
        {
            FakeContext.TouristRoutPictures.Remove(picture);
        }

        public void DeleteTouristRoutes(IEnumerable<TouristRout> routes)
        {
            FakeContext.TouristRout.RemoveRange(routes);
        }

        public void DeleteTouristRoutePictures(IEnumerable<TouristRoutPicture> pictures)
        {
            FakeContext.TouristRoutPictures.RemoveRange(pictures);
        }

        public async Task< IEnumerable<TouristRout>> GetTourisRoutsAsync(IEnumerable<Guid> ids)
        {
            return await FakeContext.TouristRout
                     .Where(xt => ids.Contains(xt.ID))
                     .ToListAsync();
        }

        public async Task< IEnumerable<TouristRoutPicture>> GetTouristRoutesPicturesAsync(Guid touristRouteID, IEnumerable<int> ids)
        {
            return await FakeContext.TouristRoutPictures
                     .Where(xt => (ids.Contains(xt.ID) && xt.TouristRoutID == touristRouteID))
                     .ToListAsync();
        }

        public async Task<ShoppingCart> GetShoopingCartByUserIdAsync(string userId)
        {
            return await FakeContext.ShoppingCarts
                         .Include(s => s.User)
                         .Include(s => s.ShoppingCartItems)
                             .ThenInclude(li => li.TouristRout)
                          .FirstOrDefaultAsync();
        }

        public async Task AddShoppingCartAsync(ShoppingCart cart)
        {
             await FakeContext.ShoppingCarts.AddAsync(cart);
        }
    }
}
