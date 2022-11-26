using Roya_DDL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_BLL.Spesification
{
    public class productFilterwithcount:BaseSpesifaction<Product>
    {
        public productFilterwithcount(ProductParams productParams) : base(c => productParams.city == null || productParams.city == c.address)
        { }
        }
}
