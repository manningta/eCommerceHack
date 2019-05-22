using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceHack.Service.Models
{
    public class CartSummary
    {
        public CartSummary(string itemName = "")
        {
            ItemSubTotal = 0;
            ShippingTotal = 0;
            ItemName = itemName;
        }

        public string ItemName;
        public decimal ItemSubTotal;
        public decimal ShippingTotal;
        public decimal OverallTotal
        {
            get { return (ShippingTotal + ItemSubTotal); }
        }
    }
}
