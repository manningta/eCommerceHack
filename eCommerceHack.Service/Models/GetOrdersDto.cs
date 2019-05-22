using eCommerceHack.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceHack.Service.Models
{
    public class GetOrdersDto
    {
        public int? ProductsPerPage { get; set; }
        public int? GetPage { get; set; }
    }
}
