using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class HouseRepository : IHouse
    {
        // Author: Mikaela Älgekrans

        private readonly ApplicationDbContext applicationDbContext;
        private readonly ICategory categoryRepository;
        private readonly ICounty countyRepository;
        private readonly IRealtor realtorRepository;
        private readonly IMunicipality municipalityRepository;

        public HouseRepository(ApplicationDbContext ApplicationDbContext, ICategory CategoryRepository, ICounty CountyRepository, IRealtor RealtorRepository, IMunicipality MunicipalityRepository) 
        {
            applicationDbContext = ApplicationDbContext;
            categoryRepository = CategoryRepository;
            countyRepository = CountyRepository;
            realtorRepository = RealtorRepository;
            municipalityRepository = MunicipalityRepository;
        }
        public async Task AddAsync(House house)
        {
            house.Municipality = await municipalityRepository.GetByIdAsync(house.Municipality.MunicipalityId);
            house.Category = await categoryRepository.GetByIdAsync(house.Category.CategoryId);
            house.County = await countyRepository.GetByIdAsync(house.County.CountyId);
            house.Realtor = await realtorRepository.GetByIdAsync(house.Realtor.Id);
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
            return await applicationDbContext.Houses.Where(x => x.HasBeenSold == false).Include(x => x.Realtor).Include(x => x.Realtor.Agency).Include(x => x.County).Include(x => x.Category).Include(x => x.Gallery).Include(x => x.Municipality).ToListAsync();
        }

        public async Task<List<House>> GetAllSoldAsync()
        {
            return await applicationDbContext.Houses.Where(x => x.HasBeenSold == true).Include(x => x.Realtor).Include(x => x.Realtor.Agency).Include(x => x.County).Include(x => x.Category).Include(x => x.Gallery).Include(x => x.Municipality).ToListAsync();
        }

        public async Task<House> GetByIdAsync(int id)
        {
            return await applicationDbContext.Houses.Include(x => x.Realtor).Include(x => x.Realtor.Agency).Include(x => x.County).Include(x => x.Category).Include(x => x.Gallery).Include(x => x.Municipality).FirstOrDefaultAsync(x => x.HouseId == id);
        }

        public async Task UpdateAsync(House house)
        {
            house.Municipality = await municipalityRepository.GetByIdAsync(house.Municipality.MunicipalityId);
            house.Category = await categoryRepository.GetByIdAsync(house.Category.CategoryId);
            house.County = await countyRepository.GetByIdAsync(house.County.CountyId);
            house.Realtor = await realtorRepository.GetByIdAsync(house.Realtor.Id);
            applicationDbContext.Houses.Update(house);
            await applicationDbContext.SaveChangesAsync();
        }

        //Author: Eden Yusof-Ioannidis
        public async Task SellAsync(int id)
        {
            House house = await GetByIdAsync(id);
            house.HasBeenSold = true;
            house.SoldDate = DateTime.Now;
            await UpdateAsync(house);
        }
    }
}
