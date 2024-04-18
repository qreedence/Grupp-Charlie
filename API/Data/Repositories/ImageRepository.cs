using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public class ImageRepository : IImage
    {
        // Author: Mikaela Älgekrans
        private readonly ApplicationDbContext applicationDbContext;
        public ImageRepository(ApplicationDbContext ApplicationDbContext)
        {
            applicationDbContext = ApplicationDbContext;
        }

        public async Task<Image> AddAsync(Image image)
        {
            {
                if (image != null)
                {
                    await applicationDbContext.Images.AddAsync(image);
                    await applicationDbContext.SaveChangesAsync();
                    return image; 
                }
                return null;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var image = await GetByIdAsync(id);
            if (image != null)
            {
                applicationDbContext.Images.Remove(image);
                await applicationDbContext.SaveChangesAsync();
                Console.WriteLine($"Image {id}# was deleted.");
            }
            Console.WriteLine("Image could not be found.");
        }

        public async Task UpdateAsync(Image image)
        {
            if (image != null)
            {
                applicationDbContext.Images.Update(image);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await applicationDbContext.Images.ToListAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await applicationDbContext.Images.FindAsync(id);
        }
    }
}
