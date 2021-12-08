namespace RedTeamAspire.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using RedTeamAspire.Models;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Fluent;
    using Microsoft.Extensions.Configuration;

    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(container1 item)
        {
            await this._container.CreateItemAsync<container1>(item, new PartitionKey(item.Pond_Key));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<container1>(id, new PartitionKey(id));
        }

        public async Task<container1> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<container1> response = await this._container.ReadItemAsync<container1>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<container1>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<container1>(new QueryDefinition(queryString));
            List<container1> results = new List<container1>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, container1 item)
        {
            await this._container.UpsertItemAsync<container1>(item, new PartitionKey(id));
        }
    }
}
