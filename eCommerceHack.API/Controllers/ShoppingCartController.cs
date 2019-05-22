using Microsoft.AspNetCore.Mvc;

namespace eCommerceHack.API.Controllers
{
    public partial class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}