using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roya_DDL.Entities;

namespace Roya_BLL.Spesification
{
    public class spesificationEvalauter<T> where T : BaseEntity
    {
        public static IQueryable<T> getQuery(IQueryable<T> inputQuery, Ispesifaction<T> spec)
        {
            var query = inputQuery;
            if (spec.Crataira != null)
                query = query.Where(spec.Crataira);

            query = spec.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));
            return query;

        }
    }
}
