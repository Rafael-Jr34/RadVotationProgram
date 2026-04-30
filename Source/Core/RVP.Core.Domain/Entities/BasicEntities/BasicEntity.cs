using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities.BasicEntities
{
   public abstract class BasicEntity
    {
        public required int Id { get; set; }
        public required bool IsActive { get; set; }
        // this have 2 purpose  
        // 1- to know if the entity is deleted if is false or
        // 2- to know if the entity is active or not if is true

    }
}
