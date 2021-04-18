using FakeXieCheng.Demo.CheckDataClassAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    [TouristRouteDifferentForTitleAndDescription]
    public class TouristRouteUpdateDto:TouristRouteBaseDto
    {
        [Required(ErrorMessage ="更改旅游资源价格必须填写")]
        public override decimal Price { get => base.Price; set => base.Price = value; }

        [Required(ErrorMessage = "更改旅游资源费用说明必须填写")]
        public override string Fees { get => base.Fees; set => base.Fees = value; }

        public ICollection<TouristRoutePicturesCreateDto> Pictures { get; set; }
        = new List<TouristRoutePicturesCreateDto>();

    }
}
