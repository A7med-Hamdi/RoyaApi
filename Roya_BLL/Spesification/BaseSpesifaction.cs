using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roya_BLL.Spesification
{
    public class BaseSpesifaction<T> : Ispesifaction<T>
    {
        public Expression<Func<T, bool>> Crataira { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }=new List<Expression<Func<T, object>>>();
        public BaseSpesifaction(Expression<Func<T, bool>> crataira)
        {
            Crataira = crataira;
           
        }
        public BaseSpesifaction()
        {

        }
        public void addIncludes(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }
    }
}
    