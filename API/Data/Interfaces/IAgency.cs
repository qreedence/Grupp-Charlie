using API.Data.Models;

//Author: Susanna Renström

namespace API.Data.Interfaces
{
    public interface IAgency
    {  
        public Task AddAsync(Agency agency);
        public Task<List<Agency>> GetAllAsync();
        public Task UpdateAsync(Agency agency);
        public Task DeleteAsync(int id);
        public Task<Agency> GetByIdAsync(int id);
        
    }

}

