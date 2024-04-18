using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Data.Repositories
{   
    public class AgencyRepository : IAgency
    {   //Author: Susanna Renström
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

        public async Task DeleteAsync(int id)
        {
            var agency = await GetByIdAsync(id);
            if (agency != null)
            {
                applicationDbContext.Agencies.Remove(agency);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Agency>> GetAllAsync()
        {
            return await applicationDbContext.Agencies.ToListAsync();
        }

        public async Task<Agency> GetByIdAsync(int id)
        {
            return await applicationDbContext.Agencies.FindAsync(id);
        }       

        public async Task UpdateAsync(Agency agency)
        {   
                applicationDbContext.Agencies.Update(agency);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }

