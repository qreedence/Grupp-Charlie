using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class MunicipalityRepository : IMunicipality
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly ICounty countyRepository;
        public MunicipalityRepository(ApplicationDbContext ApplicationDbContext, ICounty CountyRepository)
        {
            applicationDbContext = ApplicationDbContext;
            countyRepository = CountyRepository;
        }

        public async Task AddAsync(Municipality municipality)
        {
            {
                if (municipality != null)
                {
                    await applicationDbContext.Municipalities.AddAsync(municipality);
                    var county = await countyRepository.GetByNameAsync(municipality.CountyName);
                    if(county.Municipalities != null)
                    {
                        county.Municipalities.Add(municipality);
                    }
                    else
                    {
                        county.Municipalities = new List<Municipality>();
                        county.Municipalities.Add(municipality);
                    }
                    await countyRepository.UpdateAsync(county);
                    await applicationDbContext.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            var municipality = await GetByIdAsync(id);
            if (municipality != null)
            {
                applicationDbContext.Municipalities.Remove(municipality);
                await applicationDbContext.SaveChangesAsync();
                Console.WriteLine($"Municipality {id}# was deleted.");
            }
            Console.WriteLine("County could not be found.");
        }

        public async Task UpdateAsync(Municipality municipality)
        {
            if (municipality != null)
            {
                applicationDbContext.Municipalities.Update(municipality);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Municipality>> GetAllAsync()
        {
            return await applicationDbContext.Municipalities.ToListAsync();
        }

        public async Task<Municipality> GetByIdAsync(int id)
        {
            return await applicationDbContext.Municipalities.FindAsync(id);
        }
    }
}
