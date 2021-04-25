using AutoMapper;
using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.AutoMapper
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<CartLineItem, CartLineItemDto>();
        }
    }
}
