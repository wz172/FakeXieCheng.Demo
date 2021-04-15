using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public class TouristRoutDTO
    {
      
        public string Title { get; set; }
 
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

        //public ICollection<TouristRoutPicture> Pictures { get; set; }

        public double? Rating { get; set; }
        public string TravlDays { get; set; }
        public string TripType { get; set; }
        public string StratCity { get; set; }
    }
}
