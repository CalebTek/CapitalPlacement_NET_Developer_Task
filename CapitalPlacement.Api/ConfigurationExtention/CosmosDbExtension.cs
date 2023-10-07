using CapitalPlacement.Domain.Data;
using Microsoft.Azure.Cosmos;
using System;
using System.Text;

namespace CapitalPlacement.Api.ConfigurationExtention
{
    public static class CosmosDbExtension
    {
        public static void CosmosDbService(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosDbSettings = configuration.GetSection("CosmosDbSettings").Get<CosmosDbSettings>();

            var primaryKeyBytes = Encoding.UTF8.GetBytes(cosmosDbSettings.PrimaryKey);
            var primaryKeyBase64 = Convert.ToBase64String(primaryKeyBytes);

            var cosmosClient = new CosmosClient(cosmosDbSettings.EndpointUri, primaryKeyBase64);

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
