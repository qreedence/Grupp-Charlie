using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class RealtorRepository : IRealtor
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IAgency agencyRepository;

        public RealtorRepository(ApplicationDbContext ApplicationDbContext, IAgency AgencyRepository)
        {
            applicationDbContext = ApplicationDbContext;
            agencyRepository = AgencyRepository;
        }
        public async Task AddAsync(Realtor realtor)
        {
            realtor.Agency = await agencyRepository.GetByIdAsync(realtor.Agency.AgencyId);
            await applicationDbContext.Users.AddAsync(realtor);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Realtor realtor = await applicationDbContext.Users.FindAsync(id);
            if (realtor != null)
            {
                applicationDbContext.Users.Remove(realtor);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task EditAsync(Realtor realtor)
        {
            if (realtor != null)
            {
                realtor.Agency = await agencyRepository.GetByIdAsync(realtor.Agency.AgencyId);
                applicationDbContext.Users.Update(realtor);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Realtor>> GetAllAsync()
        {
            return await applicationDbContext.Users
                .Include(r => r.Agency)
                .ToListAsync();
        }

        public async Task<Realtor> GetByIdAsync(string id)
        {
            return await applicationDbContext.Users.Include(a => a.Agency).FirstOrDefaultAsync(r => r.Id == id);
        }

    }
}
