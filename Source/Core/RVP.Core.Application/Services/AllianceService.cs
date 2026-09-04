using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;


namespace RVP.Core.Application.Services
{
    public class AllianceService : IAllianceService
    {
        public Task<bool> AddAsync(Alliance entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Alliance entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Alliance>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Alliance>?> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<Alliance?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

     
    }
}
