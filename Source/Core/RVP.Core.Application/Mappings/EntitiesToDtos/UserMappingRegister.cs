using Mapster;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Domain.Entities;


namespace RVP.Core.Application.Mappings.EntitiesToDtos
{
    public class UserMappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig mapper) 
        {
            mapper.NewConfig<UserDto, User>()
                .Ignore(nameof(User.Password))
                .Ignore(nameof(User.PoliticalLeaders));

            mapper.NewConfig<User, UserDto>()
            .Ignore(nameof(User.PoliticalLeaders));
        }

    }
}
