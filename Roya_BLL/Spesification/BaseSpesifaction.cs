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
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get;set; }
        public int Take { get; set; }
        public int Skip { get;set;}
        public bool PganationEnabled { get; set; }

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
        public void AddOrderBy(Expression<Func<T,object>> orderby)
        {
           OrderBy=orderby;
        }
        public void AddOrderByDesc(Expression<Func<T,object>>orderbydesc)
        {
            OrderByDesc=orderbydesc;
        }
        public void Paganation(int take,int skip)
        {
            Take = take;
            Skip = skip;
            PganationEnabled = true;
        }
    }
}
    