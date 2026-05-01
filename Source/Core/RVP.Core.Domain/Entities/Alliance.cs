using RVP.Core.Domain.Entities.BasicEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities
{
  public  class Alliance: BasicEntity
    {
        public required int IDRecruter { get; set; }
        public required int IDSender { get; set; }
        public required byte Response { get; set; }
        /*0- waiting
         1- accepted
         2- refused
         */
        public  PoliticalParties? IdRecruter { get; set; }
        public  PoliticalParties? IdSender { get; set; }

    }
}
