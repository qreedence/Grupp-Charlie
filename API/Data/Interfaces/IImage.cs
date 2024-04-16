using API.Data.Models;

namespace API.Data.Interfaces
{
    public interface IImage
    {        
        public Task<Image> AddAsync(Image image);
        public Task UpdateAsync(Image image);
        public Task DeleteAsync(int id);
        public Task<List<Image>> GetAllAsync();
        public Task<Image> GetByIdAsync(int id);
    }
}
