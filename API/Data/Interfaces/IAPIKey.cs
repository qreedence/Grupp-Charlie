using API.Data.Models;

namespace API.Data.Interfaces
{
    public interface IAPIKey
    {
        public Task AddAsync(APIKey apiKey);
        public Task<APIKey> GetAsync();
    }
}
