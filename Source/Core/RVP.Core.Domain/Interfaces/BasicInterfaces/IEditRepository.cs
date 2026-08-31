using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Interfaces.BasicInterfaces
{
    public interface IEditRepository<T> : IGenericRepository<T> where T : class
    {
        // some entities mustn't edit, so this is for the  ones that can
        Task<T?> Edit(int id, T entity);
    }
}
