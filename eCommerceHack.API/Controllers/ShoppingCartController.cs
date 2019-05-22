using eCommerceHack.API.Models;
using eCommerceHack.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceHack.API.Controllers
{
    public partial class ShoppingCartController : Controller
    {
        private eCommerceContext _context;

        public ShoppingCartController(eCommerceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] AddItemDto item)
        {
            var res = Service.ShoppingCart.ShoppingCart.AddItem(item, _context);

            if (res == null) return new OkObjectResult(new { error = "No object created" });

            return new OkObjectResult(res);
        }
    }

    
}