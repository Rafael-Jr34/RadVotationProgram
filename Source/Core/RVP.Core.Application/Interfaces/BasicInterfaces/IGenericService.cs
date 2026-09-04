using RVP.Core.Domain.Entities.BasicDtos;


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
