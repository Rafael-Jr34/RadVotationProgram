using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Common.Enums
{
    public enum ServiceErrorCode
    {
        None = 0,
        InvalidCredentials,
        UserNotActive,
        NotFound,        
        Unauthorized,    
        ValidationError
    }
}
