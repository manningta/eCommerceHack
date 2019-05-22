using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceHack.API.Controllers
{
    public partial class ShoppingCartController : Controller
    {
    }

    public class AddItemDto
    {
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}