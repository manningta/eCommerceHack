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
        [Route("api/ShoppingCart/CartVal")]
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
        [Route("api/ShoppingCart/Complete")]
        public IActionResult Confirm([FromBody] int cartID)
        {
            var summaryObject = Service.ShoppingCart.ShoppingCart2.CreateOrder(cartID, _context);
            //if (summaryObject != null)
            //{
            //    return new OkObjectResult(summaryObject);
            //}
            //else
            //{
            //    return new NoContentResult();
            //}
        }

    }
}