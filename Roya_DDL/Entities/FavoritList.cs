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
    public class FavoritList :BaseEntity
    {

        [ForeignKey("userfavorite")]
        public string UserId { get; set; }
        public virtual User userfavorite { get; set; }
  
       
        [ForeignKey("productfavourite")]
        public int ProductId { get; set; }
        public virtual Product productfavourite { get; set; }

    }
}
