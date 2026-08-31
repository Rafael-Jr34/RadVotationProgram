using RVP.Core.Domain.Entities.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Interfaces.BasicInterfaces
{
  public   interface IGenericService<Dto>  
        where Dto: BasicDto
    {
        Task<Dto?> GetByIdAsync(int id);
        Task<List<Dto>?> GetAllAsync();

        Task<bool> AddAsync(Dto dtoE);

        Task<bool> ChangeState(int id);
    }
}
