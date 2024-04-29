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
            await applicationDbContext.Realtors.AddAsync(realtor);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Realtor realtor = await applicationDbContext.Realtors.FindAsync(id);
            if (realtor != null)
            {
                applicationDbContext.Realtors.Remove(realtor);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task EditAsync(Realtor realtor)
        {
            if (realtor != null)
            {
                applicationDbContext.Realtors.Update(realtor);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Realtor>> GetAllAsync()
        {
            return await applicationDbContext.Realtors
                .Include(r => r.Agency)
                .ToListAsync();
        }

        public async Task<Realtor> GetByIdAsync(int id)
        {
            return await applicationDbContext.Realtors.Include(a => a.Agency).FirstOrDefaultAsync(r => r.RealtorId == id);
        }

    }
}
