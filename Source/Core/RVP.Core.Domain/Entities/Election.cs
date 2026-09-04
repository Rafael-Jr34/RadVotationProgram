using RVP.Core.Domain.Entities.BasicEntities;


namespace RVP.Core.Domain.Entities
{
   public class Election: NameEntity
    {
        public required DateTime RealizationDate { get; set; }
        public  ICollection<ElectionParties>? ElectionParties { get; set; }
        public  ICollection<ElectionCandidates>? ElectionCandidates { get; set; }
        public  ICollection<ElectionPosition>? ElectionPositions { get; set; }
    }
}
