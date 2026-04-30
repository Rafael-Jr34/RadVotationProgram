using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Interfaces.BasicInterfaces
{
    public interface IEdit<T>: GenericInterface<T> where T: class
    {// some entities musnt edit, so this is for the  ones that can
        void Edit(T entity);
    }
}
