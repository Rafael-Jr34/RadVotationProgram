using Microsoft.AspNetCore.Mvc;
using RVP.Core.Application.ViewModels.Citizen;

namespace RadVotationProgram.Controllers;

public class CitizenController : Controller
{  
    public IActionResult Index()
    {

        return View("Index", (new CitizenLoginViewModel { IdentityNumber = "" }));
    }


  

}
