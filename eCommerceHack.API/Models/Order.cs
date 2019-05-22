using System;
using System.Collections.Generic;

namespace eCommerceHack.API.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
