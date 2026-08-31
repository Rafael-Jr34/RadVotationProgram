using RVP.Core.Domain.Entities.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Interfaces.BasicInterfaces
{
    public interface IServiceEdit<Dto>: IGenericService<Dto> where Dto: BasicDto
    {// some entities mustn't edit, so this is for the  ones that can
        Task<bool> Edit(Dto entity);
    }
}
