using RVP.Core.Domain.Entities.BasicEntities;

namespace RVP.Core.Application.Dtos.User
{
    public class UserDto : EmailDto
    {
        public required string Password { get; set; }
        public required byte Role { get; set; }
        // 1- admin / 2- politicalLeader
        public required string username { get; set; }
    }
}
