using FakeXieCheng.Demo.CheckDataClassAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    [TouristRouteDifferentForTitleAndDescription]
    public class TouristRouteCreateDto //: IValidatableObject
    {
        [MaxLength(100), Required(ErrorMessage = "旅游标题不能为空")]
        public string Title { get; set; }
        [Required, MaxLength(1500)]
        public string Description { get; set; }
        public decimal Price { get; set; }

        //public decimal OriginalPrice { get; set; }
        // public decimal DriinalPrice { get; set; }

        public float? DiscountPresent { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        public string Features { get; set; }

        public string Fees { get; set; }

        public string Notes { get; set; }

        public ICollection<TouristRoutePicturesCreateDto> Pictures { get; set; }
        = new List<TouristRoutePicturesCreateDto>();
        public double? Rating { get; set; }
        public string TravlDays { get; set; }
        public string TripType { get; set; }
        public string StratCity { get; set; }

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
