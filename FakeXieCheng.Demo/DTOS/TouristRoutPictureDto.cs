using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public class TouristRoutPictureDto
    {
        public int ID { get; set; }
 
        public string Url { get; set; }
        public string Destription { get; set; }
        public Guid TouristRoutID { get; set; }

        //public TouristRoutDTO TouristRout { get; set; }
    }
}
