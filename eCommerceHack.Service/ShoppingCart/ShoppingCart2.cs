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
            var cartItem = _context.ShoppingCart.FirstOrDefault(c => c.ShoppingCartId == cartID);

            if (cartItem != null)
            {
                return false;
            }

            List<CartSummary> cartSummary = new List<CartSummary>();

            //foreach (var product in cartItems.ShoppingCartItem)

            foreach (var item in cartItem.ShoppingCartItem)
            {
                var productSummary = cartSummary.FirstOrDefault(product => product.ItemName == item.Product.Name);

                if ( productSummary == null )
                {
                    productSummary = new CartSummary(item.Product.Name);
                    productSummary.ItemSubTotal += (item.Quantity * item.Product.Price);
                    productSummary.ShippingTotal += (item.Quantity * item.Product.Shipping);
                }
                else
                {
                    productSummary.ItemSubTotal += ( item.Product.Price * item.Quantity );
                    productSummary.ShippingTotal += item.Product.Shipping;
                }

                cartSummary.Add(productSummary);                
            }
            return productSummary;
        }

        public static ICollection<CartSummary> GetCartSummary(int cartID, eCommerceContext _context)
        {
            var cartItem = _context.ShoppingCart.FirstOrDefault(c => c.ShoppingCartId == cartID);

            if (cartItem != null)
            {
                return null;
            }

            List<CartSummary> cartSummary = new List<CartSummary>();

            foreach (var item in cartItem.ShoppingCartItem)
            {
                var productSummary = cartSummary.FirstOrDefault(product => product.ItemName == item.Product.Name);

                // If doesn't exist, create
                if (productSummary == null)
                {
                    productSummary = new CartSummary(item.Product.Name);
                    productSummary.ItemSubTotal += (item.Quantity * item.Product.Price);
                    productSummary.ShippingTotal += (item.Quantity * item.Product.Shipping);

                    cartSummary.Add(productSummary);
                }
                else
                {
                    productSummary.ItemSubTotal += (item.Product.Price * item.Quantity);
                    productSummary.ShippingTotal += item.Product.Shipping;
                }
            }
            return cartSummary;
        }
    }
}
