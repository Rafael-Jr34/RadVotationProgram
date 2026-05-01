
using Microsoft.EntityFrameworkCore;
using RVP.Core.Domain.Entities;
using RVP.Infrastructure.Persistence.EntityConfigurations;

namespace RVP.Infrastructure.Persistence.Context
{
    public class AppContext: DbContext

    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public DbSet<Alliance> Aliances { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidatePosition> CandidatePositions { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<ElectedPosition> ElectedPositions { get; set; }
        public DbSet<ElectionParties> ElectionParties { get; set; }
        public DbSet<ElectionPosition> ElectionPositions { get; set; }
        public DbSet<PoliticalLeaders> PoliticalLeaders { get; set; }
        public DbSet<PoliticalParties> PoliticalParties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Votes> Votes { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //liskov substitution principle
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            // Configure relationships and constraints
        }

    }
}
