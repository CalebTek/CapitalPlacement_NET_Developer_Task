

using CapitalPlacement.Domain.Data;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacement.Api.ConfigurationExtention
{
    public static class CosmosDbExtension
    {
        public static void CosmosDbService(this IServiceCollection services, IConfiguration configuration)
        {
           
            var cosmosDbSettings = configuration.GetSection("CosmosDbSettings").Get<CosmosDbSettings>();
           
            var cosmosClient = new CosmosClient(cosmosDbSettings.EndpointUri, cosmosDbSettings.PrimaryKey);

            services.AddSingleton(cosmosClient);

            services.AddSingleton(provider =>
            {
                return new DataAccess(
                    provider.GetRequiredService<CosmosClient>(),
                    cosmosDbSettings.DatabaseId,
                    cosmosDbSettings.ContainerId
                );
            });

        }
    }
}
