using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public abstract class TouristRoutePicturesBaseDto
    {
        [Required(ErrorMessage ="旅游图片信息中url是必填信息")]
        public string Url { get; set; }
        public string Destription { get; set; }
        public Guid TouristRoutID { get; set; }
    }
}
