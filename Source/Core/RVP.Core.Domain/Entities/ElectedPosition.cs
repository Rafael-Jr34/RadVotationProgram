using RVP.Core.Domain.Entities.BasicEntities;


namespace RVP.Core.Domain.Entities
{
    //this are the positions that the candidates can run for
    public class ElectedPosition: DescriptionEntity
    {
        public  ICollection<CandidatePosition>? CandidatePositions { get; set; }
        public  ICollection<ElectionCandidates>? ElectionCandidates { get; set; }
        public  ICollection<ElectionPosition>? ElectionPosition { get; set; }
    }
}
