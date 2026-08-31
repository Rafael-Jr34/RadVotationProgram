using RVP.Core.Application.ViewModels.User;

namespace RVP.Core.Application.Interfaces.HelpersInterfaces
{
    public interface IUserSession
    {
        UserSessionViewModel? GetUserSession();
        bool HasUser();
        bool IsAdmin();
    }
}