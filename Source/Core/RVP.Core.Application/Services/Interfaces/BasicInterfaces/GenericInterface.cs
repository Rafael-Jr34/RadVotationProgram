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
        Task<List<T>?> GetAllAsync();

        Task<List<T>> GetAllWithInclude();
       
        Task<bool> AddAsync(T entity);

        Task<bool> ChangeState(int id);
    }
}
