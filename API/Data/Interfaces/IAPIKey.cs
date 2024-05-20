using API.Data.Models;

//Author: Eden Yusof-Ioannidis

namespace API.Data.Interfaces
{
    public interface IAPIKey
    {
        public Task AddAsync(APIKey apiKey);
        public Task<APIKey> GetAsync();
    }
}
