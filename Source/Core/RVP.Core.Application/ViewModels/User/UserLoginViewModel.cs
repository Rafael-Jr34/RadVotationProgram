using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.ViewModels.User
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "You must enter a user name")]
        public required string Name { get; set; }


        [Required(ErrorMessage = "You must enter a password.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

    }
}
