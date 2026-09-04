
using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Entities.Interfaces;
using RVP.Infrastructure.Persistence.Context;
using RVP.Infrastructure.Persistence.Repositories.Basic_repositories;

namespace RVP.Infrastructure.Persistence.Repositories
{
    public class AllianceRepository : EditRepository<Alliance>, IAllianceRepository
    {
        public AllianceRepository(AppDBContext context) : base(context)
        {
        }
    }
}
