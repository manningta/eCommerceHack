using eCommerceHack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceHack.API.Controllers
{
    public partial class ShoppingCartController : Controller
    {
        private eCommerceContext _context;

        public ShoppingCartController(eCommerceContext context)
        {
            _context = context;
        }
    }

    public class AddItemDto
    {
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}