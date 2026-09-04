using RVP.Core.Domain.Entities.BasicEntities;

namespace RVP.Core.Domain.Entities
{
    public class Citizen: EmailEntity
    {
        public required int IdentityNumber { get; set; } //identity document number
        public  ICollection<Votes>? Votes { get; set; }
    }
}
