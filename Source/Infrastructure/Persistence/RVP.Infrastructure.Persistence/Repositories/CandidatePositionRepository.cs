using RVP.Core.Domain.Entities;
using RVP.Core.Domain.Interfaces;
using RVP.Infrastructure.Persistence.Context;
using RVP.Infrastructure.Persistence.Repositories.Basic_repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Infrastructure.Persistence.Repository
{
   public class CandidatePositionRepository : GenericRepository<CandidatePosition, AppDBContext>, ICandidatePositionRepository
    {
        public CandidatePositionRepository(AppDBContext context) : base(context)
        {
    }
}
