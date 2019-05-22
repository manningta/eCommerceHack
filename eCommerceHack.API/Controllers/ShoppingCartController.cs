using eCommerceHack.API.Models;
using eCommerceHack.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eCommerceHack.API.Controllers
{
    [Route("ShoppingCart")]
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

        [HttpGet]
        [Route("GetOrders")]
        public IActionResult GetOrders([FromBody] GetOrdersDto dto)
        {
            var res = Service.ShoppingCart.ShoppingCart.GetOrders(dto, _context);

            if (res == null || !res.Any()) return new OkObjectResult(new { error = "No orders found." });

            return new OkObjectResult(res);
        }
    }
}