using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FakeXieCheng.Demo.DTOS;

namespace FakeXieCheng.Demo.CheckDataClassAttribute
{
    public class TouristRouteDifferentForTitleAndDescriptionAttribute : ValidationAttribute
    {
        private readonly decimal MaxPrice = 2000;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //1. 获取类对象
            var touristRouteCreateDto = validationContext.ObjectInstance as  TouristRouteBaseDto;
            if (touristRouteCreateDto != null)
            {
                if (touristRouteCreateDto.Price > MaxPrice|| touristRouteCreateDto.Price==0)
                {
                    return new ValidationResult($"旅游价格[Price]不能大于{MaxPrice}或者等于零", new string[] { "TouristRouteDifferentForTitleAndDescriptionAttribute" });
                }
                if (touristRouteCreateDto.Title == touristRouteCreateDto.Description)
                {

                    return new ValidationResult("旅游名称和旅游介绍不能相同", new string[] { "TouristRouteCreateDto" });
                }
            }
            return ValidationResult.Success;
        }
    }
}
