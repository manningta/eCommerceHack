using eCommerceHack.API.Models;
using eCommerceHack.Service.Models;
using System.Linq;

namespace eCommerceHack.Service.ShoppingCart
{
    public partial class ShoppingCart3
    {
        public static IEnumerable<ShoppingCartItem> GetCart(ShoppingCartDto dto, eCommerceContext _context)
        {
            if (dto.ShoppingCartItemId == null || dto.ShoppingCartItemId < 1)
                return null;

            var ipp = dto.ItemsPerPage ?? 0;
            var pn = dto.PageNumber ?? 0;

            var cart = _context.ShoppingCartItem.FirstOrDefault(x => x.ShoppingCartId == dto.ShoppingCartID);            
            var items = cart.Order.Skip(ipp * (pn - 1)).Take(ipp);
            
            return cart;
        }

    }
}
