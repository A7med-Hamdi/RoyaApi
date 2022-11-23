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
    public class Comment : BaseEntity
    {
        public DateTime DateTime { get; set; }
        public string text { get; set; }
 
        public string UserName { get; set; }
        public string UserImage { get; set; }

        public int ProductId { get; set; }
       
       
    }
}
