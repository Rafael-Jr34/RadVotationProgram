using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Dtos.User
{
    public class UserLoginDto
    {
       
        public required string Name { get; set; }
                       
        public required string Password { get; set; }

    }
}
