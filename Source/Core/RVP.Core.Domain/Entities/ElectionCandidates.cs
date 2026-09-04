using RVP.Core.Domain.Entities.BasicEntities;


namespace RVP.Core.Domain.Entities
{ //a candidate can run for another allies parties , is need to know for which party he is running
    public class ElectionCandidates : BasicEntity
    {
        public required int IdCandidate { get; set; }
        public required int IdEllectionParty { get; set; }
        public required int IdElectedPosition { get; set; }
        public required int IdElection { get; set; }

        public  Candidate? Candidate { get; set; }
        public  ElectionParties? ElectionParty { get; set; }
        public  ElectedPosition? ElectedPosition { get; set; }
        public  Election? Election { get; set; }
        public  ICollection<Votes>? Votes { get; set; }
    }
}
