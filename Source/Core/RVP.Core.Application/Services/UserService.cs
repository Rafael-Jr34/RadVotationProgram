using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using RVP.Core.Application.Common;
using RVP.Core.Application.Common.Enums;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.Interfaces.HelpersInterfaces;
using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Interfaces;



namespace RVP.Core.Application.Services
{
   public class  UserService: EditService<User, UserDto>, IUserService  
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordEncyptor _passwordEncyptor;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper , IUserRepository userRepository, IPasswordEncyptor passwordEncyptor): base(mapper, userRepository)
        {
            _userRepository = userRepository;
            _passwordEncyptor = passwordEncyptor;
            _mapper = mapper;
        }

        public override async Task<bool> AddAsync(UserDto dto)
        {
            try
            {

                User entity = _mapper.Map<User>(dto);
                entity.Password = _passwordEncyptor.HashPassword(dto.Password);
                               
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


        public override async Task<bool> Edit(UserDto dto)
        {
            try
            {
                User? bdEntity = await _userRepository.GetByIdAsync(dto.Id);
                if (bdEntity == null) { return false;}
                var trueState = bdEntity.IsActive;
                User entity = _mapper.Map<User>(dto);
                entity.Password = string.IsNullOrEmpty(dto.Password) ? bdEntity.Password : dto.Password;
                entity.IsActive = trueState;

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



        public async Task<List<UserDto>?> GetAllWithInclude()
        {
            try
            {
                var listEntities = await _userRepository.GetListWithInclude(new List<string> { "PoliticalLeaders" }); 
                var listEntitiesDto =  _mapper.Map<List<UserDto>>(listEntities);
                  

                // tenrary operartor: this != null ? that : listEntitiesDto;
                // si eso no es igual a null, entonces haz esto, sino haz esto otro
                return listEntitiesDto;
            }
            catch (Exception)
            {
                return null;

            }
        }
        public async Task<ServiceResult<UserDto>> ConfirmUser(UserLoginDto dto)
        {
            try
            {
                var   user = await _userRepository.GetAllQuery().Where(us => us.Username == dto.Name).FirstOrDefaultAsync();
                  
                if(user == null)
                {
                    return ServiceResult<UserDto>.Fail(ServiceErrorCode.InvalidCredentials);
                }

                string password = user.Password;                          
                bool isValid = _passwordEncyptor.VerifyPassword(dto.Password, password);
                if (isValid) {
                    UserDto? Userdto = _mapper.Map<UserDto>(user);
                    if (!user.IsActive)
                    {
                        return ServiceResult<UserDto>.Fail(ServiceErrorCode.UserNotActive);
                    }
                    else
                    {
                        return ServiceResult<UserDto>.Ok(Userdto);
                    }
                }
                return ServiceResult<UserDto>.Fail(ServiceErrorCode.InvalidCredentials);
                
            }
            catch (Exception)
            {
                return ServiceResult<UserDto>.Fail(ServiceErrorCode.ValidationError );
            }
        }

      

    }
}
