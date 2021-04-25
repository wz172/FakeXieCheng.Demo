using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Models
{
    public class TouristRout
    {
        [Key,Required]
        public Guid ID { get; set; }
        [Required,MaxLength(100)]
        public string Title { get; set; }
        [Required,MaxLength(1500)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DriinalPrice { get; set; }
        [Range(0.0,1.0)]
        public float? DiscountPresent { get; set; }
        [Column(TypeName ="date")]
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        [MaxLength]
        public string Features { get; set; }
        [MaxLength]
        public string Fees { get; set; }
        [MaxLength]
        public string Notes { get; set; }
        public ICollection<TouristRoutPicture> Pictures { get; set; }
        public double? Rating { get; set; }
        public byte TravlDays { get; set; }
        public TripType? TripType { get; set; }
        public DepartureCity? StratCity { get; set; }

       

        public TouristRout()
        {
            this.Pictures = new List<TouristRoutPicture>();
        }
    }
}
