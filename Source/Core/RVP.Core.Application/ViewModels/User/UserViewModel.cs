using RVP.Core.Domain.Entities.BasicViewModels;


namespace RVP.Core.Application.ViewModels.User
{
    public class UserViewModel : EmailViewModel
    {
        public required string Password { get; set; }
        public required byte Role { get; set; }
        // 1- admin / 2- politicalLeader
        public required string Username { get; set; }
    }

}
