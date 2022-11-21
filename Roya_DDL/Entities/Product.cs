using Roya_DDL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_DDL.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string  address { get; set; }
        public virtual List<Image> Images { get; set; } = new List<Image>();

        public virtual FavoritList FavoritList { get; set; }
        public virtual Booking Bookings { get; set; } 

        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        [ForeignKey("user")]

        public string UserId { get; set; }
        public virtual User user { get; set; }

    }
}
