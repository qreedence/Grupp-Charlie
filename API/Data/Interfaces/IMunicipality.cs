using API.Data.Models;

namespace API.Data.Interfaces
{
    public interface IMunicipality
    {
        public Task AddAsync(Municipality municipality);
        public Task UpdateAsync(Municipality municipality);
        public Task DeleteAsync(int id);
        public Task<List<Municipality>> GetAllAsync();
        public Task<Municipality> GetByIdAsync(int id);
    }
}
