using RVP.Core.Domain.Entities.BasicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities
{
   public class Election: NameEntity
    {
        public required DateTime RealisationDate { get; set; }
        public virtual ICollection<ElectionParties>? ElectionParties { get; set; }
        public virtual ICollection<ElectionCandidates>? ElectionCandidates { get; set; }
        public virtual ICollection<ElectionPosition>? ElectionPositions { get; set; }
    }
}
