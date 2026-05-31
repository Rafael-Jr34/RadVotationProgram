using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Services
{
    public class ElectionService : IElectionService
    {
        public Task<bool> AddAsync(Election entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Desactive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Election>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Election>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<Election?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
