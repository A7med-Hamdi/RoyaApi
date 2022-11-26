using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roya_BLL.Spesification;

namespace Roya_BLL.interFaces
{
    public interface IGenercRepositry<T> where T : class
    {
        Task Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<IReadOnlyList<T>> GetAllDataAsync();
        Task<IReadOnlyList<T>> GetAllDataWithSpecAsync(Ispesifaction<T> spec);
        Task<T> GetDataByIdWithSpecAsync(Ispesifaction<T> spec);
        Task<int> GetCountASync(Ispesifaction<T> spec);
        Task<T> GetDataByIdAsync(int id);
        void SaveChange();
    }
}
