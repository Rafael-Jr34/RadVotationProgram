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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dtos = await _userService.GetAllAsync();
            List<UserViewModel> userlist = dtos!.Select(dto => new UserViewModel
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

        [HttpGet]
        public IActionResult Create()
        {//the user name is the key for the next login module
            return View("Save", new SaveUserViewModel()
            {
                Email = "",
                Name = "",
                LastName = "",
                Password = "",
                VerifiedPassword = "",
                Role = "",
                Username = ""
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUserViewModel vm)
        {

            if (!ModelState.IsValid)
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
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        [HttpGet]
        public async Task<IActionResult> Status(int id)
        {
            UserDto? dto = await _userService.GetByIdAsync(id);
            if (dto == null)
            {
                return View("Index");
            }
            ViewBag.Status = dto.IsActive; //1 for active, 0 for inactive
            StatusUserViewModel vm = new StatusUserViewModel
            {
                Id = id,
                Name = dto.Name,

            };

            return View("Status", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Status(StatusUserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Status", vm);
            }
            await _userService.ChangeState(vm.Id);
            return RedirectToRoute(new { controller = "User", action = "Index" });

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.EditOn = true;
            UserDto? dto = await _userService.GetByIdAsync(id);
            if (dto == null)
            {
                return View("Index");
            }
            var role = dto.Role == (byte)Role.POLITICAL_LEADER ? "B" : "A";
            EditUserViewModel vm = new EditUserViewModel
            {
                Id = id,
                Password = dto.Password,
                VerifiedPassword = dto.Password,
                Name = dto.Name,
                LastName = dto.LastName,
                Role = role,
                Username = dto.Username,
                Email = dto.Email

            };
            return View("Save", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel vm)
        {
            ViewBag.EditOn = true;
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }
            var role = vm.Role != "A" ? Role.POLITICAL_LEADER : Role.ADMIN;
            UserDto dto = new UserDto
            {
                Id = vm.Id,
                Email = vm.Email, 
                Password = (string.IsNullOrEmpty( vm.Password)) ? vm.Password! : "", 
                Role = (byte)role,
                Username = vm.Username,
                Name = vm.Name,
                LastName = vm.LastName,
                IsActive = true
            };
            await _userService.Edit(dto);
            return RedirectToRoute(new { controller = "User", action = "Index" });

        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", vm);
            }

            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login", new UserLoginViewModel { Name = "", Password = "" });
        }
    }

}
