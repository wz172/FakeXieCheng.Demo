using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public class ShoppingCartDto
    {
        public Guid Id { get; set; }
        public string UserID { get; set; }
        //public MyApplicationIdentity User { get; set; }
        public IEnumerable<CartLineItemDto> ShoppingCartItems { get; set; }
    }
}
