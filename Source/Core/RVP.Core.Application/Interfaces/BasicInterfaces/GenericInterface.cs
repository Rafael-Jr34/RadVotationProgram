using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Interfaces.BasicInterfaces
{
  public   interface GenericInterface<T>  where T: class
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetQuery();
        IQueryable<T> GetAllQuery();
        Task<List<T>> GetListWithInclude(List<string> properties);
        IQueryable<T> GetEueryWithInclude(List<string> properties);
       
        Task AddAsync(T entity);
      
        void Delete(T entity);
    }
}
