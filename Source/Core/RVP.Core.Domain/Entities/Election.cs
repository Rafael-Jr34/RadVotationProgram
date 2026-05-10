using RVP.Core.Domain.Entities.BasicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
