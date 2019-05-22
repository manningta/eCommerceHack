using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceHack.Service.Models
{
    public class AddItemDto
    {
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? ShoppingCartID { get; set; }
    }
}
