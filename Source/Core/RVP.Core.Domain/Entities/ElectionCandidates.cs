using RVP.Core.Domain.Entities.BasicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities
{ //a candidate can run for another allies parties , is need to know for which party he is running
    public class ElectionCandidates : BasicEntity
    {
        public required int IdCandidate { get; set; }
        public required int IdEllectionParty { get; set; }
        public required int IdElectedPosition { get; set; }
        public required int IdElection { get; set; }

        public virtual Candidate? Candidate { get; set; }
        public virtual ElectionParties? ElectionParty { get; set; }
        public virtual ElectedPosition? ElectedPosition { get; set; }
        public virtual Election? Election { get; set; }
        public virtual ICollection<Votes>? Votes { get; set; }
    }
}
