using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.DTOS
{
    public class CartLineItemDto
    {
        public int Id { get; set; }
        public Guid TouristID { get; set; }
        public TouristRoutDTO TouristRout { get; set; }
        public Guid? ShoppingCartId { get; set; }
        //public Guid? OrederId { get; set; }

        [Range(0.0, 1.0)]
        public float? DiscountPresent { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }
    }
}
