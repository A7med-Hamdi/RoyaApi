using Roya_DDL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }

        public int ProductId { get; set; }
     
        
    }
}
