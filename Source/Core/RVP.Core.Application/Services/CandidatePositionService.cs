using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Services
{
    public class CandidatePositionService : ICandidatePositionService
    {
        public Task<bool> AddAsync(CandidatePosition entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Desactive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CandidatePosition>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CandidatePosition>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<CandidatePosition?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
