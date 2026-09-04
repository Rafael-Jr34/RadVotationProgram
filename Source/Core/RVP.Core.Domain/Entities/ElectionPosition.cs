using RVP.Core.Domain.Entities.BasicEntities;

namespace RVP.Core.Domain.Entities
{ //these are the positions that are actived in an active election 
    public class ElectionPosition: BasicEntity
    {
        public required int IdElection { get; set; }
        public required int IdElectedPosition { get; set; }

        public  ICollection<Votes>? Votes { get; set; }
        public  Election? Election { get; set; }
        public  ElectedPosition? ElectedPosition { get; set; }
    }
}
