using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Services
{
    public class VotesService : IVotesService
    {
        public Task<bool> AddAsync(Votes entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Desactive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Votes entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Votes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Votes>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<Votes?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
