using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//Authors: Susanna Renström, Mikaela Älgekrans, Eden Yusof-Ioannidis

namespace API.Data.Repositories
{
    public class RealtorRepository : IRealtor
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IAgency agencyRepository;
        private readonly UserManager<Realtor> userManager;

        public RealtorRepository(ApplicationDbContext ApplicationDbContext, IAgency AgencyRepository, UserManager<Realtor> UserManager)
        {
            applicationDbContext = ApplicationDbContext;
            agencyRepository = AgencyRepository;
            userManager = UserManager;
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
            
            var user = await userManager.FindByIdAsync(realtor.Id);
            if (realtor.EmailConfirmed == true)
            { user.EmailConfirmed = true; }
            //var hasher = new PasswordHasher<Realtor>();
            if (user != null)
            {
                user.Agency = await agencyRepository.GetByIdAsync(realtor.Agency.AgencyId);
                user.NormalizedEmail = realtor.Email.ToUpper();
                user.NormalizedUserName = realtor.Email.ToUpper();
                user.UserName = realtor.Email;
                user.FirstName = realtor.FirstName;
                user.Avatar = realtor.Avatar;
                user.LastName = realtor.LastName;
                user.Email = realtor.Email;
                user.PhoneNumber = realtor.PhoneNumber;

                await userManager.UpdateAsync(user);
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

        public async Task<Realtor> GetByNameAsync(string username)
        {
            return await applicationDbContext.Users.Include(a => a.Agency).FirstOrDefaultAsync(r => r.UserName == username);
        }

    }
}
