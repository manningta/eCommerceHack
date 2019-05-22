using eCommerceHack.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerceHack.Service.Models;

namespace eCommerceHack.Service.ShoppingCart
{
    public partial class ShoppingCart2
    {
        public static bool CompleteOrder(int cartID, eCommerceContext _context)
        {
            var cartItems = _context.ShoppingCart.FirstOrDefault(c => c.ShoppingCartId == cartID);

            if (cartItems != null)
            {
                return false;
            }



            List<CartSummary> cartSummary = new List<CartSummary>();

            foreach (var item in cartItems.ShoppingCartItem)
            {
                cartSummary.ItemSubTotal += (item.Quantity * item.Product.Price);
                cartSummary.ShippingTotal += (item.Quantity * item.Product.Shipping);
            }
            return cartSummary;
        }

        public static ICollection<CartSummary> GetCartItems(int cartID, eCommerceContext _context)
        {
            var cartItems = _context.ShoppingCart.FirstOrDefault( c => c.ShoppingCartId == cartID);

            if (cartItems != null)
            {
                return null;
            }

            List<CartSummary> cartSummary = new List<CartSummary>();

            foreach (var item in cartItems.ShoppingCartItem)
            {
                cartSummary.ItemSubTotal += ( item.Quantity * item.Product.Price );
                cartSummary.ShippingTotal += (item.Quantity * item.Product.Shipping);
            }
            return cartSummary;
        }
    }
}
