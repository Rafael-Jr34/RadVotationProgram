using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;


namespace RVP.Core.Application.Services
{
    public class ElectionService : IElectionService
    {
        public Task<bool> AddAsync(Election entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Election>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Election>?> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<Election?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
