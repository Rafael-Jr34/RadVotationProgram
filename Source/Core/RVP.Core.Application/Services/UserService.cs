using Microsoft.EntityFrameworkCore.ChangeTracking;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Commun.Enums;
using RVP.Core.Domain.Interfaces;
using System.Threading.Tasks;


namespace RVP.Core.Application.Services
{
   public class  UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddAsync(UserDto dto)
        {
            try
            {
                User entity = new()
                {
                    Id = 0,
                    Name = dto.Name,
                    Email = dto.Email,
                    IsActive = true,
                    LastName = dto.LastName,
                    Password = dto.Password,
                    Role = dto.Role,
                    username = dto.username
                };
                User? returnEntity = await _userRepository.AddAsync(entity);
                if (returnEntity == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex) 
            {
                return false;

            }
        }

        public async Task<bool> Desactive(int id)
        {
            try
            {
              
                User? entity = await _userRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                entity.IsActive = false;
                User? returnEntity = await _userRepository.Edit(entity.Id, entity);
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

        public async Task<bool> Edit(UserDto dto)
        {
            try
            {
                User entity = new()
                {
                    Id = 0,
                    Name = dto.Name,
                    Email = dto.Email,
                    IsActive = true,
                    LastName = dto.LastName,
                    Password = dto.Password,
                    Role = dto.Role,
                    username = dto.username
                };
               User? returnEntity = await _userRepository.Edit(entity.Id, entity);
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

        public async Task<List<UserDto>?> GetAllAsync()
        {
            try
            {
               var listEntities = await _userRepository.GetAllAsync();
                var listEntitiesDto = listEntities.Select(entity => new UserDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    IsActive = entity.IsActive,
                    LastName = entity.LastName,
                    Password = entity.Password,
                    Role = entity.Role,
                    username = entity.username
                }).ToList();

                return listEntitiesDto;
            }
            catch (Exception)
            {
                return null;

            }
        }

        public async Task<List<UserDto>> GetAllWithInclude()
        {
            try
            {
                var listEntities = await _userRepository.GetListWithInclude(new List<string> { "PoliticalLeaders" }); 
                var listEntitiesDto = listEntities.Select(entity => new UserDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Email = entity.Email,
                    IsActive = entity.IsActive,
                    LastName = entity.LastName,
                    Password = entity.Password,
                    Role = entity.Role,
                    username = entity.username
                }).ToList();

                // tenrary operartor: this != null ? that : listEntitiesDto;
                // si eso no es igual a null, entonces haz esto, sino haz esto otro
                return listEntitiesDto;
            }
            catch (Exception)
            {
                return null;

            }
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            try
            {

                User? entity = await _userRepository.GetByIdAsync(id);
              
                User? returnEntity = await _userRepository.Edit(entity.Id, entity);
                if (returnEntity == null)
                {
                    return null;
                }

                UserDto dto = new()
                {
                    Id = returnEntity.Id,
                    Name = returnEntity.Name,
                    Email = returnEntity.Email,
                    IsActive = returnEntity.IsActive,
                    LastName = returnEntity.LastName,
                    Password = returnEntity.Password,
                    Role = returnEntity.Role,
                    username = returnEntity.username
                };
                return dto;
            }
            catch (Exception)
            {
                return null;

            }
        }

    }
}
