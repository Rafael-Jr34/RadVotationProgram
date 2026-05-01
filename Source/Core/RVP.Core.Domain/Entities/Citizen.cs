using RVP.Core.Domain.Entities.BasicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities
{
    public class Citizen: EmailEntity
    {
        public required int IdentityNumber { get; set; } //identity document number
        public  ICollection<Votes>? Votes { get; set; }
    }
}
