using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public class TouristRoutePicturesCreateDto
    {
        public string Url { get; set; }
        public string Destription { get; set; }
        public Guid TouristRoutID { get; set; }
    }
}
