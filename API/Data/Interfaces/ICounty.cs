using API.Data.Models;

namespace API.Data.Interfaces
{
    // Author: Mikaela Älgekrans
    public interface ICounty
    {
        public Task<County> AddAsync(County county);
        public Task UpdateAsync(County county);
        public Task DeleteAsync(int id);
        public Task<List<County>> GetAllAsync();
        public Task<County> GetByIdAsync(int id);
        public Task<County> GetByNameAsync(string name);
    }
}
