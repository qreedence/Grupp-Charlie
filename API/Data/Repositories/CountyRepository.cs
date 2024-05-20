using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

// Author: Mikaela Älgekrans

namespace API.Data.Repositories
{
    public class CountyRepository : ICounty
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CountyRepository(ApplicationDbContext ApplicationDbContext)
        {
            applicationDbContext = ApplicationDbContext;
        }

        public async Task<County> AddAsync(County county)
        {
            {
                if (county != null)
                {
                    await applicationDbContext.Counties.AddAsync(county);
                    await applicationDbContext.SaveChangesAsync();
                    return county;
                }
                return null;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var county = await GetByIdAsync(id);
            if (county != null)
            {
                applicationDbContext.Counties.Remove(county);
                await applicationDbContext.SaveChangesAsync();
                Console.WriteLine($"County {id}# was deleted.");
            }
            Console.WriteLine("County could not be found.");
        }

        public async Task UpdateAsync(County county)
        {
            if (county != null)
            {
                applicationDbContext.Counties.Update(county);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<County>> GetAllAsync()
        {
            return await applicationDbContext.Counties.Include(c => c.Municipalities).ToListAsync();
        }

        public async Task<County> GetByIdAsync(int id)
        {
            return await applicationDbContext.Counties.FindAsync(id);
        }

        public async Task<County> GetByNameAsync(string name)
        {
            return await applicationDbContext.Counties.Where(c => c.CountyName == name).FirstOrDefaultAsync();
        }
    }
}
