using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Interfaces.BasicInterfaces;
using RVP.Core.Application.Common;

namespace RVP.Core.Application.Interfaces
{
   public  interface IUserService: IServiceEdit<UserDto> 
    {
        Task<ServiceResult<UserLoginDto>>ConfirmUser(UserLoginDto dto);
    }

}
