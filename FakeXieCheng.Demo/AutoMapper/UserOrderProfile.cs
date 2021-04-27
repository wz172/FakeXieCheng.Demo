using AutoMapper;
using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.AutoMapper
{
    public class UserOrderProfile : Profile
    {
        public UserOrderProfile()
        {
            CreateMap<UserOrder, UserOrderDto>()
                    .ForMember(
                        dest => dest.OrderState,
                        original => original.MapFrom(src => src.OrderState.ToString())
                );
        }
    }
}
