using Azure;
using Microsoft.Azure.Cosmos;
using System.Net;
using System.Threading.Tasks;

namespace CapitalPlacement.Domain.Data
{
    public class DataAccess
    {
        private readonly Container _container;

        public DataAccess(CosmosClient cosmosClient, string databaseId, string containerId)
        {
            _container = cosmosClient.GetContainer(databaseId, containerId);
        }

        public async Task<ItemResponse<T>> CreateItemAsync<T>(T item, string partitionKey)
        {
            return await _container.CreateItemAsync(item, new PartitionKey(partitionKey));
        }

        public async Task<ItemResponse<T>> ReadItemAsync<T>(string itemId, string partitionKey)
        {
            return await _container.ReadItemAsync<T>(itemId, new PartitionKey(partitionKey));
        }

        public async Task<ItemResponse<T>> UpsertItemAsync<T>(T item, string partitionKey)
        {
            return await _container.UpsertItemAsync(item, new PartitionKey(partitionKey));
        }

        public async Task<ItemResponse<T>> DeleteItemAsync<T>(string itemId, string partitionKey)
        {
            return await _container.DeleteItemAsync<T>(itemId, new PartitionKey(partitionKey));
        }
    }
}
