using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Domain.Entities.BasicViewModels
{
    public abstract class DescriptionViewModel: NameViewModel
    {
        public required string Description { get; set; }
    }
}
