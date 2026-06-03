using Microsoft.AspNetCore.Mvc;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.ViewModels.User;
using RVP.Core.Domain.Commun.Enums;

namespace RadVotationProgram.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var dtos = await _userService.GetAllAsync();
            List<UserViewModel> userlist = dtos.Select(dto => new UserViewModel
            {
                Id = dto.Id,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
                Username = dto.Username,
                Name = dto.Name,
                LastName = dto.LastName,
                IsActive = dto.IsActive


            }).ToList();
            return View(userlist);
        }
        public async Task<IActionResult> Create()
        {//the user name is the key for the next login module
            return View("Save",new SaveUserViewModel() 
                { Email="", 
                  Name="",
                  LastName="",
                  Password="",
                  VerifiedPassword="", 
                  Role="",
                  Username=""});
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUserViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View("Save", vm);
            }
            var role = vm.Role != "A" ? Role.POLITICAL_LEADER : Role.ADMIN;
            UserDto dto = new UserDto
            {
                Id = vm.Id,
                Email = vm.Email,
                Password = vm.Password,
                Role = (byte)role,
                Username = vm.Username,
                Name = vm.Name,
                LastName = vm.LastName,
                IsActive = true
            };
            await _userService.AddAsync(dto);
            return RedirectToRoute(new {controller="User", action="Index"});
        }

        public async Task<IActionResult> Status()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Status(int id)
        {
            return View();
        }
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            return View();

        }
    }

}
