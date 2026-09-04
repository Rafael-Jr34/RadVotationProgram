using RVP.Core.Domain.Entities.BasicEntities;

namespace RVP.Core.Domain.Entities
{
 public   class 
        Candidate: LastNameEntity
    {
        public required byte Photo { get; set; }
        public required int IdParty { get; set; }//party who created it
        public  PoliticalParties? PoliticalParties { get; set; }
        public  ICollection<CandidatePosition>? CandidatePositions { get; set; }
        public  ICollection<ElectionCandidates>? ElectionCandidates { get; set; }
    }
}
