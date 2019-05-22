using eCommerceHack.API.Models;
using eCommerceHack.Service.Models;
using System.Linq;

namespace eCommerceHack.Service.ShoppingCart
{
    public partial class ShoppingCart3
    {       
        public static ShoppingCartItem GetCart(GetItem item, eCommerceContext _context)
        {
            if (!_context.ShoppingCart.Any(x => x.ShoppingCartID = item.ShopppingCartID)) return null;

            if (item.Quantity <= 0) return null;

            //var cart = _context.

            return GetCart;
        }

    }
}
