using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a user name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "You must enter a last name.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "You must enter an Email.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "You must enter a password.")]
        public required string Password { get; set; }


        [Required(ErrorMessage = "You must confirm the password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public required string VerifiedPassword { get; set; }


        [Required(ErrorMessage = "You must select a role.")]
        public required string Role { get; set; }

        [Required(ErrorMessage = "You must enter a user name the password")]
         public required string Username { get; set; }
    }
}
