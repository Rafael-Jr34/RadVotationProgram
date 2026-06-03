using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Services
{
    public class PoliticalLeadersService : IPoliticalLeadersService
    {
        public Task<bool> AddAsync(PoliticalLeaders entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PoliticalLeaders>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<PoliticalLeaders>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<PoliticalLeaders?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
