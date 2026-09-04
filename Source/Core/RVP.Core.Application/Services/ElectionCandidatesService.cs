using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;


namespace RVP.Core.Application.Services
{
    public class ElectionCandidatesService : IElectionCandidatesService
    {
        public Task<bool> AddAsync(ElectionCandidates entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectionCandidates>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectionCandidates>?> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<ElectionCandidates?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
