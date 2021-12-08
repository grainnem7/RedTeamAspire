namespace RedTeamAspire.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RedTeamAspire.Models;

    public interface ICosmosDbService
    {
        Task<IEnumerable<container1>> GetItemsAsync(string query);
        Task<container1> GetItemAsync(string id);
        Task AddItemAsync(container1 item);
        Task UpdateItemAsync(string id, container1 item);
        Task DeleteItemAsync(string id);
    }
}
