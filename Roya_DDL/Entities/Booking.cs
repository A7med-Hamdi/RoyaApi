using Roya_DDL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_DDL.Entities
{
    public class Booking : BaseEntity
    {
        public bool Stutes { get; set; } = false;

        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("userbooking")]
        public string UserId { get; set; }
        public virtual User userbooking { get; set; }

        [ForeignKey("productbooking")]
        public int ProductId { get; set; }
        public virtual Product productbooking { get; set; }
     
        
    }
}
