using RVP.Core.Domain.Entities.BasicViewModels;


namespace RVP.Core.Application.ViewModels.User
{
    public class UserSessionViewModel : EmailViewModel
    {
        public required byte Role { get; set; }
        // 1- admin / 2- politicalLeader
        public required string Username { get; set; }
    }
}
