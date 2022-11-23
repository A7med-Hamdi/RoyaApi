using Roya_DDL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_BLL.Spesification
{
    public class ProductSpec:BaseSpesifaction<Product>
    {
        public ProductSpec()
        {
            addIncludes(i => i.Images);
            addIncludes(c => c.Comments);
        }
        public ProductSpec(int id):base(b=>b.Id==id)
        {
            addIncludes(i => i.Images);
            addIncludes(c => c.Comments);
        }

    }
}
