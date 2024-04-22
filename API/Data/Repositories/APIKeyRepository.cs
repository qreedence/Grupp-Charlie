using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

//Author: Eden Yusof-Ioannidis

namespace API.Data.Repositories
{
    public class APIKeyRepository : IAPIKey
    {   
        private ApplicationDbContext applicationDbContext;

        public APIKeyRepository(ApplicationDbContext ApplicationDbContext)
        {
            applicationDbContext = ApplicationDbContext;
        }

        public async Task AddAsync(APIKey apiKey)
        {
            await applicationDbContext.ApiKeys.AddAsync(apiKey);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<APIKey> GetAsync()
        {
            return await applicationDbContext.ApiKeys.OrderByDescending(a => a.DateRegistered).FirstOrDefaultAsync();
        }
    }
}
