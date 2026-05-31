using  RVP.Core.Domain.Entities.BasicDtos;

namespace RVP.Core.Application.Dtos.User
{
    public class UserDto : EmailDto
    {
        public required string Password { get; set; }
        public required byte Role { get; set; }
        // 1- admin / 2- politicalLeader
        public required string Username { get; set; }
    }
}
