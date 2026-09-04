using RVP.Core.Domain.Entities.BasicEntities;


namespace RVP.Core.Domain.Entities
{
    public class CandidatePosition : BasicEntity
    {//the actual position of the candidate in the election
        public required int IDCandidate { get; set; }
        public required int IdElectedPosition { get; set; }

        public  Candidate? Candidate { get; set; }
        public  ElectedPosition? ElectedPosition { get; set; }
    }
}
