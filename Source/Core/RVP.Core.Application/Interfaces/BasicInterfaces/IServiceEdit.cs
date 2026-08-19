using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Interfaces.BasicInterfaces
{
    public interface IServiceEdit<T>: GenericInterface<T> where T: class
    {// some entities mustn't edit, so this is for the  ones that can
        Task<bool> Edit(T entity);
    }
}
