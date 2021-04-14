using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Models
{
    public class TouristRoutPicture
    {
        [Key,Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(255)]
        public string Url { get; set; }
        public string Destription { get; set; }
        public Guid TouristRoutID { get; set; }
        public TouristRout TouristRout { get; set; }
    }
}
