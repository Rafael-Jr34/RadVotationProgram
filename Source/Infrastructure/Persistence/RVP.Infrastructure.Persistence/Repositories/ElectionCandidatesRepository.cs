using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Interfaces;
using RVP.Infrastructure.Persistence.Context;
using RVP.Infrastructure.Persistence.Repositories.Basic_repositories;


namespace RVP.Infrastructure.Persistence.Repositories
{
    public class ElectionCandidatesRepository: GenericRepository<ElectionCandidates>, IElectionCandidatesRepository
    {
        public ElectionCandidatesRepository(AppDBContext context) : base(context)
        {
        }
    }
}
 