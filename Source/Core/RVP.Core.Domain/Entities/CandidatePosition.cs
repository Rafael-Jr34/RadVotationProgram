using RVP.Core.Domain.Entities.BasicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities
{
    public class CandidatePosition : BasicEntity
    {//the actual position of the candidate in the election
        public required int IDCandidate { get; set; }
        public required int IdElectedPosition { get; set; }

        public virtual Candidate? Candidate { get; set; }
        public virtual ElectedPosition? ElectedPosition { get; set; }
    }
}
