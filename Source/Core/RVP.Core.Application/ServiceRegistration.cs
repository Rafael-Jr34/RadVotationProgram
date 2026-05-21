using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RVP.Core.Application.Interfaces;
using RVP.Core.Application.Services;
using RVP.Core.Application.Servicies;


namespace RVP.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddServiceLayerIoc(this IServiceCollection services)
        {
            #region Repositorios IOC
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

            #endregion
        }
    }
}
