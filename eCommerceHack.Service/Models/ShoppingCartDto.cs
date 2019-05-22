using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceHack.Service.Models
{
    public class ShoppingCartDto
    {
        public int? ShoppingCartID { get; set;}
        public int? ItemsPerPage { get; set; }
        public int? PageNumber { get; set; }
    }
}
