using RVP.Core.Domain.Entities.BasicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities
{
 public   class 
        Candidate: LastNameEntity
    {
        public required byte Photo { get; set; }
        public required int IdParty { get; set; }//party who created it
        public virtual PoliticalParties? PoliticalParties { get; set; }
        public virtual ICollection<CandidatePosition>? CandidatePositions { get; set; }
        public virtual ICollection<ElectionCandidates>? ElectionCandidates { get; set; }
    }
}
