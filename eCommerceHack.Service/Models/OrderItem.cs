using System;
using System.Collections.Generic;

namespace eCommerceHack.API.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
