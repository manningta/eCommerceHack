using System;
using System.Collections.Generic;

namespace eCommerceHack.API.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartItem = new HashSet<ShoppingCartItem>();
        }

        public int ShoppingCartId { get; set; }
        public DateTime LastUpdated { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}
