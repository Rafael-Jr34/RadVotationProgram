using RVP.Core.Domain.Entities.BasicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities
{
   public class PoliticalParties: DescriptionEntity
    {
        public required int Acronym { get; set; }
        public required byte Logo { get; set; }

        public  ICollection<Alliance>? AllianceIdRecruter { get; set; }
        public  ICollection<Alliance>? AllianceIdSender { get; set; }
        public  ICollection<Candidate>? Candidates { get; set; }
        public  ICollection<ElectionParties>? ElectionParties { get; set; }
        public  ICollection<PoliticalLeaders>? PoliticalLeader { get; set; }

    }
}
