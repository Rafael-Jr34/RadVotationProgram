using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Services
{
    public class PoliticalPartiesService : IPoliticalPartiesService

    {
        public Task<bool> AddAsync(PoliticalParties entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(PoliticalParties entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<PoliticalParties>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<PoliticalParties>?> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<PoliticalParties?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
