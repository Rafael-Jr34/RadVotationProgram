using Microsoft.AspNetCore.Mvc;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.ViewModels;

namespace RadVotationProgram.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private UserController(IUserService userService)
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
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id)
        {
            return View();
        }

        public async Task<IActionResult> Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
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
