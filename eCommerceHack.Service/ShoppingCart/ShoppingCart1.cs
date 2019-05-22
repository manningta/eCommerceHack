using eCommerceHack.API.Models;
using eCommerceHack.Service.Models;
using System.Linq;

namespace eCommerceHack.Service.ShoppingCart
{
    public partial class ShoppingCart
    {
        public bool AddItem(AddItemDto item, eCommerceContext _context)
        {
            if (!_context.Product.Any(x => x.ProductId == item.ProductId)) return false;

            if (item.Quantity <= 0) return false;

            if (!_context.ShoppingCart.Any(x => x.ShoppingCartId == item.ShoppingCartID))
                _context.ShoppingCart.Add(new API.Models.ShoppingCart())

            return true;
        }
    }
}
