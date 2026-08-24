using RVP.Core.Application.ViewModels.User;
using RVP.Core.Application.Helpers;
using RVP.Core.Application.Interfaces.HelpersInterfaces;


namespace RadVotationProgram.Middlewares
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserSession(IHttpContextAccessor httpContextAccessor)
        {

            _httpContextAccessor = httpContextAccessor;

        }
        public bool HasUser()
        {
            UserSessionViewModel? userSession = _httpContextAccessor.HttpContext?
                .Session.Get<UserSessionViewModel>("User");
            if (userSession == null)
            {
                return false;
            }
            return true;

        }
        public UserSessionViewModel? GetUserSession()
        {
            UserSessionViewModel? userSession = _httpContextAccessor.HttpContext?
                .Session.Get<UserSessionViewModel>("User");
            if (userSession == null)
            {
                return null;
            }
            return userSession;

        }
    }
}
