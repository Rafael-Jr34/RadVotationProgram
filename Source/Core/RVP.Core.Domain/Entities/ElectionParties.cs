using RVP.Core.Domain.Entities.BasicEntities;


namespace RVP.Core.Domain.Entities
{
    public class ElectionParties: BasicEntity
    { //parties that are in an actual election
        public required int IdElection { get; set; }
        public required int IdPoliticalParty { get; set; }
        public  ICollection<ElectionCandidates>? ElectionCandidates { get; set; }
        public  Election? Election { get; set; }
        public  PoliticalParties? PoliticalParty { get; set; }
    }

}
