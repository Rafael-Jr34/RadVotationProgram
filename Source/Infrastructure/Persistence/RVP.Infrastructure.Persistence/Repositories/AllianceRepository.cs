using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Entities.Interfaces;
using RVP.Infrastructure.Persistence.Context;
using RVP.Infrastructure.Persistence.Repositories.Basic_repositories;
namespace RVP.Infrastructure.Persistence.Repository
{
    public class AllianceRepository : EditRepository<Alliance, AppDBContext>, IAllianceRepository
    {
        public AllianceRepository(AppDBContext context) : base(context)
        {
        }
    }
}
