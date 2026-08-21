using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Helpers;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.ViewModels.Citizen;
using RVP.Core.Application.ViewModels.User;

namespace RadVotationProgram.Controllers
{
    public class LoginController : Controller
    {
      
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
                return RedirectToRoute(new { controller = "User", action = "Index" });
                
            }

            ViewBag.ErrorMessage = result.ErrorCode.ToUserMessage();
            return View("Login",vm);
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
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
