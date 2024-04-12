using API.Data.Models;

namespace API.Data.Interfaces
{
    public interface IAgency
    {  
        public Task AddAsync(Agency agency);
        public Task<List<Agency>> GetAllAsync();
        public Task UpdateAsync(Agency agency);
        public Task DeleteAsync(Agency agency);
        public Task<Agency> GetByIdAsync(int id);
       
    }

}

