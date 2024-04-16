using API.Data.Models;

namespace API.Data.Interfaces
{
    public interface IAgency
    {  //Author; Susanna
        public Task AddAsync(Agency agency);
        public Task<List<Agency>> GetAllAsync();
        public Task UpdateAsync(Agency agency);
        public Task DeleteAsync(int id);
        public Task<Agency> GetByIdAsync(int id);
        
    }

}

