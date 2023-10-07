using CapitalPlacement.Domain.Data;
using CapitalPlacement.Infrastructure.Implementation;
using CapitalPlacement.Infrastructure.Interface;
using CapitalPlacement.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CapitalPlacement.Infrastructure
{
    public static class InfrastructureInjection
    {
        public static void InjectInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosDbSettings = new CosmosDbSettings()
            {
                EndpointUri = configuration["CosmosDbSettings.EndpointUri"],
                PrimaryKey = configuration["CosmosDbSettings:PrimaryKey"],
                DatabaseId = configuration["CosmosDbSettings:DatabaseId"],
                ContainerId = configuration["CosmosDbSettings:ContainerId"]
            };
            services.AddScoped<IApplicationFormRepository, ApplicationFormRepository>();
            services.AddScoped<IProgramDetailsRepository, ProgramDetailsRepository>();
            services.AddSingleton(cosmosDbSettings);        }

    }
}