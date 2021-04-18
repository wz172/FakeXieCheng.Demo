using FakeXieCheng.Demo.CheckDataClassAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    [TouristRouteDifferentForTitleAndDescription]
    public class TouristRouteCreateDto : TouristRouteBaseDto//: IValidatableObject
    {

        public virtual ICollection<TouristRoutePicturesCreateDto> Pictures { get; set; }

        ////类内部的校验
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //    {
        //        yield return new ValidationResult("旅游名称和旅游介绍不能相同", new string[] { "TouristRouteCreateDto" });
        //    }
        //}
    }
}
