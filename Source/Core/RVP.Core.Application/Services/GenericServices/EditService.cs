using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using RVP.Core.Application.Common;
using RVP.Core.Application.Common.Enums;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.Interfaces.BasicInterfaces;
using RVP.Core.Application.Interfaces.HelpersInterfaces;
using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Entities.BasicDtos;
using RVP.Core.Domain.Entities.BasicEntities;
using RVP.Core.Domain.Interfaces;
using RVP.Core.Domain.Interfaces.BasicInterfaces;



namespace RVP.Core.Application.Services
{
   public class  EditService<Entity, DtoModel>:GenericService<Entity, DtoModel> , IServiceEdit<DtoModel>
        where DtoModel : BasicDto
       where Entity : BasicEntity
    {
        private readonly IEditRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public EditService(IMapper mapper , IEditRepository<Entity> repository): base(mapper, repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        public virtual async Task<bool> Edit(DtoModel dto)
        {
            try
            {
                Entity? bdEntity = await _repository.GetByIdAsync(dto.Id);
                if (bdEntity == null) { return false;}
                var trueState = bdEntity.IsActive;
                Entity entity = _mapper.Map<Entity>(dto);
                entity.IsActive = trueState;

                Entity? returnEntity = await _repository.Edit(bdEntity.Id, entity);
                if (returnEntity == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception )
            {
                return false;

            }
        }
       

    }
}
