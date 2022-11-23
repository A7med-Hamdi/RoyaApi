using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roya_BLL.Spesification
{
    public interface Ispesifaction<T>
    {
        public Expression<Func<T ,bool>> Crataira { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
    }
}
