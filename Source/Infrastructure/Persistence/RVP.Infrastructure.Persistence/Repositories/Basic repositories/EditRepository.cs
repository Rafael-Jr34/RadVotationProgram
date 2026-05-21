using Microsoft.EntityFrameworkCore;
using RVP.Core.Domain.Interfaces.BasicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVP.Infrastructure.Persistence.Repositories.Basic_repositories
{
    public class EditRepository<Entity, Context> : 
        GenericRepository<Entity, Context>, 
        IEdit<Entity>
        where Entity : class
        where Context : DbContext
    {
        private readonly Context _context;
        public EditRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Entity?> Edit(int id, Entity entity)
        {
            var entry = await _context.Set<Entity>().FindAsync(id);
            if (entry != null)
            {
                _context.Entry(entry).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entry;


            }
            return null;
        }
    }
}
