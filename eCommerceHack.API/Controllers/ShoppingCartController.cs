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

        public IActionResult AddItem([FromBody] AddItemDto item)
        {
            eCommerceHack.Service.ShoppingCart.ShoppingCart
        }
    }

    
}