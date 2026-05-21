using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Interfaces.BasicInterfaces
{
  public   interface IGenericRepository<T>  where T: class
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetAllQuery();
        Task<List<T>> GetListWithInclude(List<string> properties);
        IQueryable<T> GetQueryWithInclude(List<string> properties);
       Task AddAsync(T entity);
    }
}
