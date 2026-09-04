using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using RVP.Core.Application.Dtos.User;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.Interfaces.HelpersInterfaces;
using RVP.Core.Application.ViewModels.User;
using RVP.Core.Domain.Common.Enums;


namespace RadVotationProgram.Controllers
{
    public class ElectoralPositionController : Controller
    {
        private readonly IUserService _userService;
        private readonly IElectedPositionService _ElectoralPositionService;
        private readonly IMapper _mapper;
        private readonly IUserSession _userSession;
        public ElectoralPositionController(IUserService userService, IMapper mapper, IUserSession userSession, IElectedPositionService electorlPositionService)
        {
            _userService = userService;
            _mapper = mapper;
            _userSession = userSession;
            _ElectoralPositionService = electorlPositionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            #region Verication UserSesion
            var (hasUser, action) = VerificationUserSession();
            if (!hasUser)
            {
                return action!;

            }
            #endregion
            var dtos = await _ElectoralPositionService.GetAllAsync();
            
            List<ElectoralPositionViewModel>? ElectoralPositionlist = dtos !=null ? _mapper.Map<List<ElectoralPositionViewModel>>(dtos) : null;
           
            return View(ElectoralPositionlist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            #region Verication UserSesion
            var (hasUser, action) = VerificationUserSession();
            if (!hasUser)
            {
                return action!;

            }
            #endregion

            //the user name is the key for the next login module
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
            #region Verication UserSesion
            var (hasUser, action) = VerificationUserSession();
            if (!hasUser)
            {
                return action!;

            }
            #endregion

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
            #region Verication UserSesion
            var (hasUser, action) = VerificationUserSession();
            if (!hasUser)
            {
                return action!;

            }
            #endregion

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
            #region Verication UserSesion
            var (hasUser, action) = VerificationUserSession();
            if (!hasUser)
            {
                return action!;

            }
            #endregion

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
            #region Verication UserSesion
            var (hasUser, action) = VerificationUserSession();
            if (!hasUser)
            {
                return action!;

            }
            #endregion

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
            #region Verication UserSesion
            var (hasUser, action) = VerificationUserSession();
            if (!hasUser)
            {
                return action!;

            }
            #endregion


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
        private  (bool, ActionResult?) VerificationUserSession()
        {
            var hasUser = true;
            if (!_userSession.HasUser())
            {
                hasUser = false;
                return (hasUser, RedirectToRoute(new { controller = "Login", action = "LoginUser" }));

            }
            return (hasUser, null);
            
        }


    }

}
 