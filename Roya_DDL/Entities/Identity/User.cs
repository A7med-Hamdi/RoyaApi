using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_DDL.Entities.Identity
{
    public class User : IdentityUser
    {
        public Addreses? Addreses { get; set; }
        public string? ImageName { get; set; }
        public virtual List<Product>? Products { get; set; } = new List<Product>();
        public virtual List<Booking>? Bookings { get; set; } = new List<Booking>();
        public virtual List<FavoritList>?  FavoritLists { get; set; } = new List<FavoritList>();
    }
}
