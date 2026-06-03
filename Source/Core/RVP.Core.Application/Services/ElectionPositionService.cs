using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Services
{
    public class ElectionPositionService : IElectionPositionService
    {
        public Task<bool> AddAsync(ElectionPosition entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectionPosition>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectionPosition>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<ElectionPosition?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
