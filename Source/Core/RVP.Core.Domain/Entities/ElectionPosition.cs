using RVP.Core.Domain.Entities.BasicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities
{ //these are the positions that are actived in an active election 
    public class ElectionPosition: BasicEntity
    {
        public required int IdElection { get; set; }
        public required int IdElectedPosition { get; set; }

        public virtual ICollection<Votes>? Votes { get; set; }
        public virtual Election? Election { get; set; }
        public virtual ElectedPosition? ElectedPosition { get; set; }
    }
}
