using eCommerceHack.API.Models;
using eCommerceHack.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eCommerceHack.Service.ShoppingCart
{
    public static partial class ShoppingCart
    {
        public static ShoppingCartItem AddItem(AddItemDto item, eCommerceContext _context)
        {
            if (!_context.Product.Any(x => x.ProductId == item.ProductId)) return null;

            if (item.Quantity <= 0) return null;

            API.Models.ShoppingCart cart = _context.ShoppingCart.FirstOrDefault(x => x.ShoppingCartId == item.ShoppingCartID);

            if (cart == null)
                cart = new API.Models.ShoppingCart()
                {
                    LastUpdated = DateTime.Now
                };

            var cartItem = new ShoppingCartItem()
            {
                ProductId = item.ProductId ?? 0,
                Quantity = item.Quantity ?? 0
            };

            cart.ShoppingCartItem = new[] { cartItem };

            _context.SaveChanges();

            return cartItem;
        }

        public static IEnumerable<Order> GetOrders(GetOrdersDto dto, eCommerceContext _context)
        {
            if (dto.GetPage == null || dto.GetPage < 1)
                return null;
            if (dto.ProductsPerPage == null || dto.ProductsPerPage < 1)
                return null;

            var ppp = dto.ProductsPerPage ?? 0;
            var gp = dto.GetPage ?? 0;

            var orders = _context.Order.Skip(ppp * (gp - 1)).Take(ppp);

            return orders;
        }
    }
}
