using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{   
    public class CategoryRepository : ICategory
    {   //Author: Susanna Renström
        private readonly ApplicationDbContext applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task AddAsync(Category category)
        {
            await applicationDbContext.Categories.AddAsync(category);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category != null) 
            { 
            applicationDbContext.Categories.Remove(category);
            await applicationDbContext.SaveChangesAsync();
        }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await applicationDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await applicationDbContext.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            applicationDbContext.Categories.Update(category);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
