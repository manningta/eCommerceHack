using eCommerceHack.API.Models;
using eCommerceHack.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace eCommerceHack.API.Controllers
{
    public partial class ShoppingCartController : Controller
    {
        private eCommerceContext _context;

        public ShoppingCartController(eCommerceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return new OkObjectResult("Success.");
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] AddItemDto item)
        {
            var res = Service.ShoppingCart.ShoppingCart.AddItem(item, _context);

            if (res == null) return new OkObjectResult(new { error = "No object created" });

            return new OkObjectResult(new
            {
                res.ShoppingCartItemId,
                res.ShoppingCartId,
                res.ProductId,
                res.Quantity
            });
        }

        [HttpGet]
        public IActionResult GetOrders([FromBody] GetOrdersDto dto)
        {
            var res = Service.ShoppingCart.ShoppingCart.GetOrders(dto, _context);

            if (res == null || !res.Any()) return new OkObjectResult(new { error = "No orders found." });

            return new OkObjectResult(res.Select(r => new
            {
                r.OrderDate,
                r.OrderId,
                r.OrderItem
            }).ToArray());
        }
    }
}