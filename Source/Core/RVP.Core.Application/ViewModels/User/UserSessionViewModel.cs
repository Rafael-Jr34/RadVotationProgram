using RVP.Core.Domain.Entities.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.ViewModels.User
{
    public class UserSessionViewModel : EmailViewModel
    {
        public required byte Role { get; set; }
        // 1- admin / 2- politicalLeader
        public required string Username { get; set; }
    }
}
