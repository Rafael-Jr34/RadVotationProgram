using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Helpers;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.ViewModels.User;
using RVP.Core.Domain.Common.Enums;
using System.Threading.Tasks;

namespace RadVotationProgram.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dtos = await _userService.GetAllAsync();
            
            List<UserViewModel>? userlist = dtos !=null ? _mapper.Map<List<UserViewModel>>(dtos) : null;
           
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
            UserDto dto = _mapper.Map<UserDto>(vm);
            dto.Role = (byte)role;

           
            await _userService.AddAsync(dto);
            return RedirectToAction("Index");
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
                UserName = dto.Username,

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
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            UserDto? dto = await _userService.GetByIdAsync(id);
            if (dto == null)
            {
                return View("Index");
            }
            var role = dto.Role == (byte)Role.POLITICAL_LEADER ? "B" : "A";
            EditUserViewModel vm = _mapper.Map<EditUserViewModel>(dto);
            vm.Role = role;
        
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel vm)
        {
           
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var role = vm.Role != "A" ? Role.POLITICAL_LEADER : Role.ADMIN;
            UserDto dto = _mapper.Map<UserDto>(vm);
            dto.Role = (byte)role;
           
            await _userService.Edit(dto);
            return RedirectToRoute(new { controller = "User", action = "Index" });

        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            UserLoginDto dto = _mapper.Map<UserLoginDto>(vm);       

            var result = await _userService.ConfirmUser(dto);
            if (result.Success) {
                return RedirectToAction("Index");
                
            }

            ViewBag.ErrorMessage = result.ErrorCode.ToUserMessage();
            return View(vm);
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View( new UserLoginViewModel { Name = "", Password = "" });
        }
    }

}
