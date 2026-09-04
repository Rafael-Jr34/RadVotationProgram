using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;


namespace RVP.Core.Application.Services
{
    public class CandidateService : ICandidateService
    {
        public Task<bool> AddAsync(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Candidate>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Candidate>?> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<Candidate?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
