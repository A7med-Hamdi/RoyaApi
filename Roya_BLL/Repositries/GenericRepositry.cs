using Microsoft.EntityFrameworkCore;
using Roya_BLL.interFaces;
using Roya_BLL.Spesification;
using Roya_DDL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_BLL.Repositries
{
    public class GenericRepositry<T> : IGenercRepositry<T> where T : class
    {
        private readonly RoyaContext context;

        public GenericRepositry(RoyaContext _context)
        {
           context = _context;
        }
        public async Task Add(T entity)
            => await context.Set<T>().AddAsync(entity);

        public T Delete(T entity)
            => context.Set<T>().Remove(entity).Entity;

        public async Task<IReadOnlyList<T>> GetAllDataAsync()
            
            => await context.Set<T>().ToListAsync();

        public async Task<T> GetDataByIdAsync(int id)
       
            => await context.Set<T>().FindAsync(id);

        public void SaveChange()
        {
            context.SaveChanges();
        }

        public  T Update(T entity)
            =>  context.Set<T>().Update(entity).Entity;
        public async Task<IReadOnlyList<T>> GetAllDataWithSpecAsync(Ispesifaction<T> spec)
        {
            return await ApplySpesifacation(spec).ToListAsync();
        }
        public async Task<T> GetDataByIdWithSpecAsync(Ispesifaction<T> spec)
        {
            return await ApplySpesifacation(spec).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplySpesifacation(Ispesifaction<T> spec)
        {
            return spesificationEvalauter<T>.getQuery(context.Set<T>(), spec);

        }
    }

}
