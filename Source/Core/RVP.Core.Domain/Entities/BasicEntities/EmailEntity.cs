using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities.BasicEntities
{
   public abstract  class EmailEntity: LastNameEntity
    {
        public required string Email { get; set; }
    }

}
