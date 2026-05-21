using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RVP.Core.Domain.Entities.Interfaces;
using RVP.Core.Domain.Interfaces;
using RVP.Infrastructure.Persistence.Context;
using RVP.Infrastructure.Persistence.Repositories;
using RVP.Infrastructure.Persistence.Repository;

 

namespace RVP.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayerIoc(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts configuration
            if (configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                services.AddDbContext<AppDBContext>(opt =>
                opt.UseInMemoryDatabase("TestingDB"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDBContext>(opt =>
                opt.UseSqlServer(connectionString, m =>
                m.MigrationsAssembly(typeof(AppDBContext).Assembly.FullName)), 
                ServiceLifetime.Transient);
                //ServiceLifetime.Transient is used to give a new context every call
                // the MigrationsAssembly thing is just to no create the migrations in another project

            }


            #endregion
            #region Repositorios IOC
            services.AddTransient<IPoliticalPartiesRepository, PoliticalPartiesRepository>();
            services.AddTransient<IPoliticalLeadersRepository, PoliticalLeadersRepository>();
            services.AddTransient<IElectionPartiesRepository, ElectionPartiesRepository>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<IVotesRepository, VotesRepository>();
            services.AddTransient<ICitizenRepository, CitizenRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAllianceRepository, AllianceRepository>();
            services.AddTransient<ICandidatePositionRepository, CandidatePositionRepository>();
            services.AddTransient<IElectedPositionRepository, ElectedPositionRepository>(); 
            services.AddTransient<IElectionRepository, ElectionRepository>();
            services.AddTransient<IElectionCandidatesRepository, ElectionCandidatesRepository>();
            services.AddTransient<IVotesRepository, VotesRepository>();
            
            #endregion
        }
    }//some inyection of services for the persistence layer
}
