using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;

namespace RVP.Core.Application.Services
{
    public class CandidatePositionService : ICandidatePositionService
    {
        public Task<bool> AddAsync(CandidatePosition entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CandidatePosition>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CandidatePosition>?> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<CandidatePosition?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
