using System;
using System.Collections.Generic;

namespace eCommerceHack.API.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Shipping { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}
