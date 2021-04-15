using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Models;

namespace FakeXieCheng.Demo.AutoMapper
{
    public class TouristRoutAutoMapperProfile : Profile
    {
        public TouristRoutAutoMapperProfile()
        {
            CreateMap<TouristRout, TouristRoutDTO>().ForMember(
               dest => dest.Price,
               original => original.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPresent ?? 1))
                )
                .ForMember(
                dest => dest.TravlDays,
                original => original.MapFrom(src => src.TravlDays.ToString() + "天")
                )
                .ForMember(
                    dest => dest.TripType,
                    original => original.MapFrom(src => src.TripType.ToString())
                )
                .ForMember(
                dest => dest.StratCity,
                original => original.MapFrom(src => src.StratCity.ToString())
                );

        }
    }
}
