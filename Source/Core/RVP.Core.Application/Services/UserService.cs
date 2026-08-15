using Microsoft.EntityFrameworkCore.ChangeTracking;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.Interfaces.HelpersInterfaces;
using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Interfaces;



namespace RVP.Core.Application.Services
{
   public class  UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordEncyptor _passwordEncyptor;
        public UserService(IUserRepository userRepository, IPasswordEncyptor passwordEncyptor)
        {
            _userRepository = userRepository;
            _passwordEncyptor = passwordEncyptor;
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
                    Password = _passwordEncyptor.HashPassword(dto.Password),
                    Role = dto.Role,
                    Username = dto.Username
                };
                User? returnEntity = await _userRepository.AddAsync(entity);
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

        public async Task<bool> ChangeState(int id)
        {
            try
            {
              
                User? entity = await _userRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }

               entity.IsActive = entity.IsActive == false ? true : false;
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
                User? bdEntity = await _userRepository.GetByIdAsync(dto.Id);
                if (bdEntity == null) { return false;}


                User entity = new()
                {
                    Id = 0,
                    Name = dto.Name,
                    Email = dto.Email,
                    IsActive = true,
                    LastName = dto.LastName,
                    Password = string.IsNullOrEmpty(dto.Password)? bdEntity.Password : dto.Password,
                    Role = dto.Role,
                    Username = dto.Username
                };
               User? returnEntity = await _userRepository.Edit(bdEntity.Id, entity);
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
                    Username = entity.Username
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
                    Username = entity.Username
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
                    Username = returnEntity.Username
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
