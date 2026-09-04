using RVP.Core.Application.Common.Enums;

namespace RVP.Core.Application.Helpers
{
   
        public static class ServiceErrorMessages
        {
            private static readonly Dictionary<ServiceErrorCode, string> _messages = new()
            {
                [ServiceErrorCode.InvalidCredentials] = "User or Password  are incorrect.",
                [ServiceErrorCode.UserNotActive] = "This account is not active.",
                [ServiceErrorCode.NotFound] = "Resource not found.",
                [ServiceErrorCode.Unauthorized] = "You dont have access to do this action."
            };

            public static string ToUserMessage(this ServiceErrorCode code) =>
                _messages.TryGetValue(code, out var msg) ? msg : "An unexpected error has occurred.";
        }
    
}
