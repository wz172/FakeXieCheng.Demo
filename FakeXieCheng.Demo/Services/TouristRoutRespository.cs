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

        public IEnumerable<TouristRout> GetTourisRouts(TouristRouteRequestParam touristRouteParam)
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

            return resultQueryable
                .ToList();
        }

        public TouristRout GetTouristRout(Guid id)
        {
            return FakeContext.TouristRout
                .Where(xt => xt.ID == id)
                .Include(xt => xt.Pictures)
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

        public void AddTouristRoute(TouristRout rout)
        {
            FakeContext.TouristRout.Add(rout);
        }

        public bool Save()
        {
            return FakeContext.SaveChanges() > 0;
        }

        public void AddTouristRoutePicture(Guid tourisrRouteId, TouristRoutPicture picture)
        {
            if (!JudgeTouristRouteExist(tourisrRouteId) || picture == null)
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

        public IEnumerable<TouristRout> GetTourisRouts(IEnumerable<Guid> ids)
        {
            return FakeContext.TouristRout
                     .Where(xt => ids.Contains(xt.ID))
                     .ToList();
        }

        public IEnumerable<TouristRoutPicture> GetTouristRoutesPictures(Guid touristRouteID, IEnumerable<int> ids)
        {
            return FakeContext.TouristRoutPictures
                     .Where(xt => (ids.Contains(xt.ID) && xt.TouristRoutID == touristRouteID))
                     .ToList();
        }
    }
}
