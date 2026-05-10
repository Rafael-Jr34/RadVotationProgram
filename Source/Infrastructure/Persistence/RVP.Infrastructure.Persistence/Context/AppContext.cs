
using Microsoft.EntityFrameworkCore;
using RVP.Core.Domain.Entities;
using RVP.Infrastructure.Persistence.EntityConfigurations;
using System.Reflection;

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
            #region Aplying Entity Configurations on model builder
            /*
            modelBuilder.ApplyConfiguration(new AllianceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CandidatePositionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CitizenEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ElectedPositionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ElectionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ElectionCandidatesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ElectionPartiesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ElectedPositionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PoliticalLeadersEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PoliticalPartiesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VotesEntityConfiguration());
            You could make all of this or just use the assembly method to apply all configurations in the assembly
            */
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion

            // Configure relationships and constraints
        }

    }
}
