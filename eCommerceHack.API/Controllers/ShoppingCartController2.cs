using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using eCommerceHack.Service.Models;
using eCommerceHack.API.Models;

namespace eCommerceHack.API.Controllers
{
    public partial class ShoppingCartController : Controller
    {
        [HttpGet]
        public IActionResult GetCartValue([FromBody] int cartID)
        {
            var summaryObject = Service.ShoppingCart.ShoppingCart2.GetCartSummary(cartID, _context);
            if (summaryObject != null)
            {
                return new OkObjectResult(summaryObject);
            }
            else
            {
                return new NoContentResult();
            }
        }

        [HttpPost]
        public IActionResult Confirm([FromBody] int cartID)
        {
            bool successful = Service.ShoppingCart.ShoppingCart2.CompleteOrder(cartID, _context);
            if (successful)
            {
                return new OkObjectResult("Success");
            }
            else
            {
                return new NoContentResult();
            }
        }

    }
}