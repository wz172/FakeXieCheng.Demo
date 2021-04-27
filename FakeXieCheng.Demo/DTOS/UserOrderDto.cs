using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public class UserOrderDto
    {
        public Guid Id { get; set; }
        public string UserID { get; set; }
        public IEnumerable<CartLineItemDto> UserOrderCartItems { get; set; }
        public DateTime CreateTimeUtc { get; set; }
        public string OrderState { get; set; }
        public string ThirdPartyPayMent { get; set; }
    }
}
