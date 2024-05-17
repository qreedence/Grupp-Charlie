using API.Data.Models;

//Author: Susanna Renström

namespace API.Data.Interfaces
{
    public interface ICategory
    {   
        public Task AddAsync(Category category);
        public Task<List<Category>> GetAllAsync();
        public Task UpdateAsync(Category category);
        public Task DeleteAsync(int id);
        public Task<Category> GetByIdAsync(int id);
    }
}
