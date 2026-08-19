using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Interfaces.HelpersInterfaces
{
    public interface IPasswordEncyptor
    {
        string HashPassword(string password);
        bool VerifyPassword(string Inpassword, string outPassword);

    }
}
