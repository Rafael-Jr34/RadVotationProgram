using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;


namespace RVP.Core.Application.Services
{
    public class ElectionPartiesService : IElectionPartiesService
    {
        public Task<bool> AddAsync(ElectionParties entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectionParties>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectionParties>?> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<ElectionParties?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
