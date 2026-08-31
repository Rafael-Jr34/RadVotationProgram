using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RVP.Core.Application.Helpers;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.Interfaces.BasicInterfaces;
using RVP.Core.Application.Interfaces.HelpersInterfaces;
using RVP.Core.Application.Services;
using System.Reflection;



namespace RVP.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddServiceLayerIoc(this IServiceCollection services)
        {
            #region Configurations

            var mapsterConfig = new TypeAdapterConfig();
            mapsterConfig.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(mapsterConfig);
            services.AddScoped<IMapper, ServiceMapper>();

            #endregion
            #region Services IOC
            services.AddScoped(typeof(IGenericService<>),typeof( GenericService<,>));
            services.AddTransient<IPoliticalLeadersService, PoliticalLeadersService>();
            services.AddTransient<IAllianceService, AllianceService >();
            services.AddTransient<IPoliticalPartiesService, PoliticalPartiesService>();
            services.AddTransient<IElectionPartiesService, ElectionPartiesService>();
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IVotesService, VotesService>();
            services.AddTransient<ICitizenService, CitizenService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICandidatePositionService, CandidatePositionService>();
            services.AddTransient<IElectedPositionService, ElectedPositionService>();
            services.AddTransient<IElectionService, ElectionService>();
            services.AddTransient<IElectionCandidatesService, ElectionCandidatesService>();
            services.AddTransient<IElectionPositionService, ElectionPositionService>();
            services.AddTransient<IPasswordEncyptor, PasswordEncryptor>();
            
            #endregion
        }
    }
}
