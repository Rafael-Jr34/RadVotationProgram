using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.ViewModels.Citizen
{
    public class CitizenLoginViewModel
    {
        [Required(ErrorMessage = "Identity Number is required.")]
        [Display(Name = "Identity Number")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Identity Number must be exactly 11 digits.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Identity Number must contain only numbers.")]
        public string IdentityNumber { get; set; } = string.Empty;
    }
}
