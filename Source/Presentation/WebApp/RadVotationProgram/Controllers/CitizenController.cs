 using Microsoft.AspNetCore.Mvc;
using RadVotationProgram.Models;
using RVP.Core.Application.ViewModels.Citizen;
using System.Diagnostics;

namespace RadVotationProgram.Controllers;

public class CitizenController : Controller
{  
    public IActionResult Index()
    {

        return View("Index", (new CitizenLoginViewModel { IdentityNumber = "" }));
    }


  

}
