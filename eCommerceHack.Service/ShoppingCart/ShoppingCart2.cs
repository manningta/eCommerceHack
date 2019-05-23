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
            bool success = false;
            
            try
            {
                var cart = _context.ShoppingCart.FirstOrDefault(c => c.ShoppingCartId == cartID);

                // CartID doesn't exist
                if (cart == null)
                {
                    return false;
                }

                var newOrder = new Order();

                newOrder.OrderId = 0;
                newOrder.OrderDate = DateTime.UtcNow;

                _context.Database.BeginTransaction();

                // Aggregate items (consolidate duplicates)
                List<CartSummary> cartSummary = new List<CartSummary>();

                foreach (var item in cart.ShoppingCartItem)
                {
                    var productSummary = cartSummary.FirstOrDefault(product => product.ItemName == item.Product.Name);

                    if (productSummary == null)
                    {
                        productSummary = new CartSummary(item.Product.Name);
                        productSummary.ItemSubTotal += (item.Quantity * item.Product.Price);
                        productSummary.ShippingTotal += (item.Quantity * item.Product.Shipping);
                    }
                    else
                    {
                        productSummary.ItemSubTotal += (item.Product.Price * item.Quantity);
                        productSummary.ShippingTotal += item.Product.Shipping;
                    }

                    cartSummary.Add(productSummary);
                }

                // Create order
                _context.Add(newOrder);

                // Create order items
                int i = 0;
                foreach (var item in cartSummary)
                {
                    _context.Add(
                        new OrderItem() { OrderId = 0
                        , OrderItemId = 0
                        , Quantity = (int)cartSummary[i].ItemSubTotal, TotalCost = ((int)cartSummary[i].ItemSubTotal) 
                            * cart.ShoppingCartItem.Count(prod => prod.Product.Name == cartSummary[i].ItemName)
                        , ProductId = cart.ShoppingCartItem.FirstOrDefault( p => p.Product.Name == cartSummary[i].ItemName ).ProductId });
                    i++;
                }

                // Empty Cart
                var items = _context.ShoppingCartItem.Where(item => item.ShoppingCartId == cartID);

                foreach (var item in items)
                {
                    _context.Remove(item);
                }

                if (items != null)
                {
                    _context.SaveChanges();
                }
                success = true;
            }
            catch (Exception e)
            {
                if (_context.Database.CurrentTransaction != null)
                {
                    _context.Database.RollbackTransaction();
                }
                throw e;
            }
            return success;
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
