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
            services.AddScoped<IPoliticalLeadersService, PoliticalLeadersService>();
            services.AddScoped<IAllianceService, AllianceService >();
            services.AddScoped<IPoliticalPartiesService, PoliticalPartiesService>();
            services.AddScoped<IElectionPartiesService, ElectionPartiesService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IVotesService, VotesService>();
            services.AddScoped<ICitizenService, CitizenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICandidatePositionService, CandidatePositionService>();
            services.AddScoped<IElectedPositionService, ElectedPositionService>();
            services.AddScoped<IElectionService, ElectionService>();
            services.AddScoped<IElectionCandidatesService, ElectionCandidatesService>();
            services.AddScoped<IElectionPositionService, ElectionPositionService>();
            services.AddScoped<IPasswordEncyptor, PasswordEncryptor>();
            
            #endregion
        }
    }
}
