using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Models
{
    public class ShoppingCart
    {
        [Key]
        public Guid Id { get; set; }
        public string UserID { get; set; }
        public MyApplicationIdentity User { get; set; }
        public IEnumerable<CartLineItem> ShoppingCartItems { get; set; }

    }
}
