using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roya_BLL.interFaces
{
    public interface IGenercRepositry<T> where T : class
    {
        Task Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<IReadOnlyList<T>> GetAllDataAsync();
        Task<T> GetDataByIdAsync(int id);
        void SaveChange();
    }
}
