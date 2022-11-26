using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roya_DDL.Entities;

namespace Roya_BLL.Spesification
{
    public class spesificationEvalauter<T> where T : class
    {
        public static IQueryable<T> getQuery(IQueryable<T> inputQuery, Ispesifaction<T> spec)
        {
            var query = inputQuery;
            if (spec.Crataira != null)
                query = query.Where(spec.Crataira);
            if(spec.OrderBy!=null)
                query = query.OrderBy(spec.OrderBy);
            if(spec.OrderByDesc!=null)
                query=query.OrderByDescending(spec.OrderByDesc);
            if(spec.PganationEnabled)
                query=query.Skip(spec.Skip).Take(spec.Take);

            query = spec.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));
            return query;

        }
    }
}
