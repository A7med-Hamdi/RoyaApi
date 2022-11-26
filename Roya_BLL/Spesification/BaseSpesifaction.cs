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
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagingEnvled { get; set; }
        public BaseSpesifaction()
        {

        }
        public BaseSpesifaction(Expression<Func<T, bool>> criteria)
        {
            Crataira = criteria;
        }

        public void AddInclude(Expression<Func<T, object>> includeExpretions)
        {

            Includes.Add(includeExpretions);

        }

        public void AddOrderBy(Expression<Func<T, object>> orderByExpration)
        {
            OrderBy = orderByExpration;
        }
        public void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpretions)
        {
            OrderByDesc = orderByDescExpretions;
        }
        public void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnvled = true;
        }
    }
}
    