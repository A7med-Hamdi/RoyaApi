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
    public class Comment 
    {
        public DateTime DateTime { get; set; }
        public string text { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("usercomment")]
        public string UserId { get; set; }
        public virtual User usercomment { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("productcomment")]

        public int ProductId { get; set; }
        public virtual Product productcomment { get; set; }
       
    }
}
