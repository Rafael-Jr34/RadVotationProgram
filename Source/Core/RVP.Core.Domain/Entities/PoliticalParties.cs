using RVP.Core.Domain.Entities.BasicEntities;

namespace RVP.Core.Domain.Entities
{
   public class PoliticalParties: DescriptionEntity
    {
        public required string Acronym { get; set; }
        public required byte Logo { get; set; }

        public  ICollection<Alliance>? AllianceIdRecruter { get; set; }
        public  ICollection<Alliance>? AllianceIdSender { get; set; }
        public  ICollection<Candidate>? Candidates { get; set; }
        public  ICollection<ElectionParties>? ElectionParties { get; set; }
        public  ICollection<PoliticalLeaders>? PoliticalLeader { get; set; }

    }
}
