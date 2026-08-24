using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Helpers;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.Interfaces.HelpersInterfaces;
using RVP.Core.Application.ViewModels.Citizen;
using RVP.Core.Application.ViewModels.User;
using RVP.Core.Domain.Common.Enums;

namespace RadVotationProgram.Controllers
{
    public class LoginController : Controller
    {
      
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserSession _userSession;
        public LoginController(IUserService userService, IMapper mapper, IUserSession userSession)
        {
            _userService = userService;
            _mapper = mapper;
            _userSession = userSession;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserLoginViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("Login",vm);
            }
            UserLoginDto dto = _mapper.Map<UserLoginDto>(vm);

            var result = await _userService.ConfirmUser(dto);
            if (result.Success)
            {
                var sessionObject = _mapper.Map<UserSessionViewModel>(result.Data!);
                
                HttpContext.Session.Set<UserSessionViewModel>("User", sessionObject);
                if(sessionObject.Role == (Byte)Role.ADMIN)
                {
                    return RedirectToRoute(new { controller = "User", action = "Index" });

                }
                return RedirectToRoute(new { controller = "Citizen", action = "Index" });


            }

            ViewBag.ErrorMessage = result.ErrorCode.ToUserMessage();
            return View("Login",vm);
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
            if (_userSession.HasUser())
            {
                UserSessionViewModel? userSession = _userSession.GetUserSession();
                switch (userSession!.Role)
                {
                    case (Byte)Role.ADMIN:
                        return RedirectToRoute(new { controller = "User", action = "Index" });
                        
                    case (Byte)Role.POLITICAL_LEADER:
                        return RedirectToRoute(new { controller = "Login", action = "LoginCitizen" });

                    default:
                        return RedirectToRoute(new { controller = "Login", action = "LoginCitizen" });


                }


            }
            return View("Login",new UserLoginViewModel { Name = "", Password = "" });
        }

        [HttpPost]
        public IActionResult LoginCitizen(CitizenLoginViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", vm);
            }

            return RedirectToRoute(new { controller = "Citizen", action = "Index" });
        }
    }
}
