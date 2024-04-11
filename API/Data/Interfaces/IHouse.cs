using API.Data.Models;
namespace API.Data.Interfaces
{
    public interface IHouse
    {
        public Task AddAsync(House house);

        public Task<List<House>> GetAllAsync();
    }
}
