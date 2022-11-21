using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_DDL.Entities
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("product")]
        public int productid { get; set; }
        public virtual Product product { get; set; }
    }
}
