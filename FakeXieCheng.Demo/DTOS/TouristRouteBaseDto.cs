using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public abstract  class TouristRouteBaseDto
    {
        [MaxLength(100), Required(ErrorMessage = "旅游标题不能为空")]
        public string Title { get; set; }
        [Required, MaxLength(1500)]
        public string Description { get; set; }
        public virtual decimal Price { get; set; }

        //public decimal OriginalPrice { get; set; }
        // public decimal DriinalPrice { get; set; }

        public float? DiscountPresent { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        public string Features { get; set; }

        public virtual string Fees { get; set; }

        public string Notes { get; set; }

        public double? Rating { get; set; }
        public string TravlDays { get; set; }
        public string TripType { get; set; }
        public string StratCity { get; set; }
    }
}
