using eCommerceHack.API.Models;
using eCommerceHack.Service.Models;
using Microsoft.AspNetCore.Mvc;
using eCommerceHack.Service.ShoppingCart;

namespace eCommerceHack.API.Controllers
{
    public partial class ShoppingCartController : Controller
    {
        private eCommerceContext _context;

        public ShoppingCartController(eCommerceContext context)
        {
            _context = context;
        }
        
        public IActionResult GetCart([FromBody] ShoppingCartDto cartDto)
        {
            var cartDto = Service.ShoppingCart.ShoppingCart.GetCart(item, _context);

            if (cartDto == null) return new OkObjectResult(new { error = "No items found in cart" });

            return new OkObjectResult(cartDto);
        }
    }


}