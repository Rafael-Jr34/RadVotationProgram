using RVP.Core.Application.Interfaces;
using RVP.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Core.Application.Services
{
    public class CitizenService : ICitizenService
    {
        public Task<bool> AddAsync(Citizen entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeState(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Citizen entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Citizen>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Citizen>?> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public Task<Citizen?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
