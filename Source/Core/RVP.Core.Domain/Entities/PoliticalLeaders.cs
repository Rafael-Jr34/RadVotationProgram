using RVP.Core.Domain.Entities.BasicEntities;

namespace RVP.Core.Domain.Entities
{
    public class PoliticalLeaders: BasicEntity
    {
        public required int IdPoliticalParty { get; set; }
        public required int IdLeader { get; set; }
        public  PoliticalParties? PoliticalParty { get; set; }
        public  User? Leader { get; set; }
    }
}
