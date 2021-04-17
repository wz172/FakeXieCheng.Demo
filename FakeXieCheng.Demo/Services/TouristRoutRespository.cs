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
            if (touristRouteParam.RatingLogicType!=LogicType.Null)
            {
                switch (touristRouteParam.RatingLogicType)
                {
                    case LogicType.Null:
                        break;
                    case LogicType.LessThen:
                        resultQueryable = resultQueryable.Where(xt => xt.Rating < touristRouteParam.RatingValue);
                        break;
                    case LogicType.EqualTo:
                        resultQueryable = resultQueryable.Where(xt => xt.Rating ==touristRouteParam.RatingValue);
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
