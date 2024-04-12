using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Data.Repositories
{   
    public class AgencyRepository : IAgency
    {
        private ApplicationDbContext applicationDbContext;

        public AgencyRepository(ApplicationDbContext ApplicationDbContext)
        {
            applicationDbContext = ApplicationDbContext;
        }
        public async Task AddAsync(Agency agency)
        {
            await applicationDbContext.Agencies.AddAsync(agency);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Agency agency)
        {
                applicationDbContext.Agencies.Remove(agency);
                await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Agency>> GetAllAsync()
        {
            return await applicationDbContext.Agencies.ToListAsync();
        }

        public async Task<Agency> GetByIdAsync(int id)
        {
            return applicationDbContext.Agencies.FirstOrDefault(a => a.AgencyId == id);
        }       

        public async Task UpdateAsync(Agency agency)
        {   
                applicationDbContext.Agencies.Update(agency);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }

