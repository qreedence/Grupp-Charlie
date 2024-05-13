using API.Data.Models;

namespace API.Data.Interfaces
{
    public interface IRealtor
    {
        public Task AddAsync(Realtor realtor);
        public Task<List<Realtor>> GetAllAsync();
        public Task<Realtor> GetByIdAsync(string id);
        public Task<Realtor> GetByNameAsync(string username);
        public Task EditAsync(Realtor realtor);
        public Task DeleteAsync(string id);
    }
}
