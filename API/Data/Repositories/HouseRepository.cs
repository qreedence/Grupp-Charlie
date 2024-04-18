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

        public async Task DeleteAsync(int id)
        {
            
           //var house = await GetByIdAsync(id);
            var house = await applicationDbContext.Houses.Include(h => h.Gallery).FirstOrDefaultAsync(h => h.HouseId == id);
            if (house != null)
       
            {
                applicationDbContext.Images.RemoveRange(house.Gallery);
                applicationDbContext.Houses.Remove(house);
              
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<House>> GetAllAsync()
        {
            return await applicationDbContext.Houses.ToListAsync();
        }

        public async Task<House> GetByIdAsync(int id)
        {
            return await applicationDbContext.Houses.FindAsync(id);
        }

        public async Task UpdateAsync(House house)
        {
            applicationDbContext.Houses.Update(house);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
