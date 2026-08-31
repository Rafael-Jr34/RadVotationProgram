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
   public class  GenericService<Entity, DtoModel> : IGenericService<DtoModel>
    
        where Entity : BasicEntity
        where DtoModel : BasicDto
      {
        private readonly IEditRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IMapper mapper , IEditRepository<Entity> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<bool> AddAsync(DtoModel dto)
        {
            try
            {

                Entity entity = _mapper.Map<Entity>(dto);
                               
                Entity? returnEntity = await _repository.AddAsync(entity);
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

        public virtual async Task<bool> ChangeState(int id)
        {
            try
            {
              
                Entity? entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }

               entity.IsActive = entity.IsActive ? false : true;
                Entity? returnEntity = await _repository.Edit(entity.Id, entity);
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


        public virtual async Task<List<DtoModel>?> GetAllAsync()
        {
            try
            {
               var listEntities = await _repository.GetAllAsync();
                var listEntitiesDto = _mapper.Map<List<DtoModel>>(listEntities);


                return listEntitiesDto;
            }
            catch (Exception)
            {
                return null;

            }
        }

    
        public virtual async Task<DtoModel?> GetByIdAsync(int id)
        {
            try
            {

                Entity? entity = await _repository.GetByIdAsync(id);
              if( entity == null) return null;
                Entity? returnEntity = await _repository.Edit(entity.Id, entity);
                if (returnEntity == null)
                {
                    return null;
                }

                DtoModel dto = _mapper.Map<DtoModel>(returnEntity);
               
                return dto;
            }
            catch (Exception)
            {
                return null;

            }
        }

      
        
    }
}
