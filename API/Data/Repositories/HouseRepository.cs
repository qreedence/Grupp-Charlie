using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class HouseRepository : IHouse
    {
        private readonly ApplicationDbContext applicationDbContext;
        public HouseRepository(ApplicationDbContext ApplicationDbContext) 
        {
            applicationDbContext = ApplicationDbContext;
        }

        public async Task AddAsync(House house)
        {
            await applicationDbContext.Houses.AddAsync(house);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<House>> GetAllAsync()
        {
            return await applicationDbContext.Houses.ToListAsync();
        }
    }
}
