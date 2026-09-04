using RVP.Core.Domain.Entities.BasicEntities;

namespace RVP.Core.Domain.Entities
{
   public class User: EmailEntity
    {
        public required string Password { get; set; }
        public required byte Role { get; set; }
        // 1- admin / 2- politicalLeader
        public required string Username { get; set; }
        public  PoliticalLeaders? PoliticalLeaders { get; set; }
    }
}
