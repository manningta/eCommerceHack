using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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