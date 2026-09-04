using Mapster;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.ViewModels.User;

namespace RVP.Core.Application.Mappings.DtosToViewModels
{
    public class UserDtoMappings : IRegister 
    {
        public void Register(TypeAdapterConfig mapper)
        {

            mapper.NewConfig<UserDto, UserViewModel>();

            mapper.NewConfig<SaveUserViewModel, UserDto>()
                .Ignore(nameof(UserDto.Role))
                .Map(dest => dest.IsActive, src => false);

            mapper.NewConfig<UserDto, EditUserViewModel>()
                .Ignore(nameof(EditUserViewModel.Role))
                .Map(dest => dest.VerifiedPassword, src => src.Password)
                .Map(dest => dest.Password, src => src.Password);
            
            mapper.NewConfig<EditUserViewModel, UserDto>()
                .Ignore(nameof(UserDto.Role))
                .Ignore(nameof(EditUserViewModel.VerifiedPassword))
                .Map(dest => dest.Password, 
                     src => string.IsNullOrEmpty( src.Password) ? "" : src.Password)
                .Map(dest => dest.IsActive, src => false);

            mapper.NewConfig<UserLoginViewModel, UserDto>();

            mapper.NewConfig<UserDto, UserSessionViewModel>()
                .Ignore(nameof(UserDto.Password));






        }
    }
}
