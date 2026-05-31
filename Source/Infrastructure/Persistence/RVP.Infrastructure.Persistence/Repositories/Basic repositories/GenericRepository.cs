using Microsoft.EntityFrameworkCore;
using RVP.Core.Domain.Interfaces.BasicInterfaces;
using RVP.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Infrastructure.Persistence.Repositories.Basic_repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity>
        where Entity : class
        
    {
        private readonly AppDBContext _context;
        public GenericRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Entity> AddAsync(Entity entity)
        {
            await _context.Set<Entity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        //the delete option is going in se services logic, 'cause is just an edit of status.

        public async Task<List<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();
        }

        public IQueryable<Entity> GetAllQuery()
        {
            return _context.Set<Entity>().AsQueryable();
        }

        public async Task<Entity?> GetByIdAsync(int id)
        {
            return await _context.Set<Entity>().FindAsync(id);
        }

        public IQueryable<Entity> GetQueryWithInclude(List<string> properties)
        {
            IQueryable<Entity> query = _context.Set<Entity>();

            foreach (var property in properties)
            {
                query = query.Include(property);
            }

            return query;
        }

        public async Task<List<Entity>> GetListWithInclude(List<string> properties)
        {
            IQueryable<Entity> query = _context.Set<Entity>();

            foreach (var property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();

        }
    }
      
}
