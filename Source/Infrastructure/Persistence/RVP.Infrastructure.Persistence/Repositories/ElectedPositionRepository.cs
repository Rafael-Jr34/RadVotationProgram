using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Interfaces;
using RVP.Infrastructure.Persistence.Context;
using RVP.Infrastructure.Persistence.Repositories.Basic_repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Infrastructure.Persistence.Repositories
{
    public class ElectedPositionRepository : EditRepository<ElectedPosition>, IElectedPositionRepository
    {
        public ElectedPositionRepository(AppDBContext context) : base(context)
        {
        }
    } 
    
}
