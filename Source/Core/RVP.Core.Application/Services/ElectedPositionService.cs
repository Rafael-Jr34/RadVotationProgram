using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Services
{
    public class ElectedPositionService : IElectedPositionService
    {
        public Task<bool> AddAsync(ElectedPosition entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(ElectedPosition entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectedPosition>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ElectedPosition>?> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<ElectedPosition?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
