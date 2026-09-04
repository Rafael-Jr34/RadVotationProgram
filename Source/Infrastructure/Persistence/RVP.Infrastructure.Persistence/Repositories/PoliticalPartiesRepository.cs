using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Interfaces;
using RVP.Infrastructure.Persistence.Context;
using RVP.Infrastructure.Persistence.Repositories.Basic_repositories;


namespace RVP.Infrastructure.Persistence.Repositories
{
    public class PoliticalPartiesRepository : EditRepository<PoliticalParties>, IPoliticalPartiesRepository
    {
        public PoliticalPartiesRepository(AppDBContext context) : base(context)
        {
        }
    }
}
