using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Models;

namespace FakeXieCheng.Demo.AutoMapper
{
    public class TouristRoutPictureMapperProFile:Profile
    {
        public TouristRoutPictureMapperProFile()
        {
            CreateMap<TouristRoutPicture, TouristRoutPictureDto>();

            CreateMap<TouristRoutePicturesCreateDto, TouristRoutPicture>();

            CreateMap<TouristRoutePicturesUpdateDto, TouristRoutPicture>();

            CreateMap<TouristRoutPicture, TouristRoutePicturesUpdateDto>();
        }


    }
}
