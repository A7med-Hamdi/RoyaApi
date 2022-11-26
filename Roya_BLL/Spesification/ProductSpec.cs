using Roya_DDL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_BLL.Spesification
{
    public class ProductSpec : BaseSpesifaction<Product>
    {
        public ProductSpec(ProductParams productParams) : base(c => productParams.city==null ||productParams.city == c.address)
        {
            addIncludes(i => i.Images);
            addIncludes(c => c.Comments);
            Paganation(productParams.PageSize *(productParams.PageIndex-1),productParams.PageSize);
            AddOrderBy(p => p.Name);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }
        public ProductSpec(int id) : base(b => b.Id == id)
        {
            addIncludes(i => i.Images);
            addIncludes(c => c.Comments);
        }

    }
}
