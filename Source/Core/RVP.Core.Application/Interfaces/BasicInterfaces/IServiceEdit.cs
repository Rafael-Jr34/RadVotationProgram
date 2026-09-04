using RVP.Core.Domain.Entities.BasicDtos;


namespace RVP.Core.Application.Interfaces.BasicInterfaces
{
    public interface IServiceEdit<Dto>: IGenericService<Dto> where Dto: BasicDto
    {// some entities mustn't edit, so this is for the  ones that can
        Task<bool> Edit(Dto entity);
    }
}
