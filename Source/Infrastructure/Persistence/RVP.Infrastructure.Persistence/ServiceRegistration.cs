using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RVP.Core.Domain.Entities.Interfaces;
using RVP.Core.Domain.Interfaces;
using RVP.Core.Domain.Interfaces.BasicInterfaces;
using RVP.Infrastructure.Persistence.Context;
using RVP.Infrastructure.Persistence.Repositories;
using RVP.Infrastructure.Persistence.Repositories.Basic_repositories;


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
            #region Repositories IOC
            services.AddScoped<IPoliticalPartiesRepository, PoliticalPartiesRepository>();
            services.AddScoped<IPoliticalLeadersRepository, PoliticalLeadersRepository>();
            services.AddScoped<IElectionPartiesRepository, ElectionPartiesRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IVotesRepository, VotesRepository>();
            services.AddScoped<ICitizenRepository, CitizenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAllianceRepository, AllianceRepository>();
            services.AddScoped<ICandidatePositionRepository, CandidatePositionRepository>();
            services.AddScoped<IElectedPositionRepository, ElectedPositionRepository>(); 
            services.AddScoped<IElectionRepository, ElectionRepository>();
            services.AddScoped<IElectionCandidatesRepository, ElectionCandidatesRepository>();
            services.AddScoped<IVotesRepository, VotesRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            #endregion
        }
    }//some inyection of services for the persistence layer
}
