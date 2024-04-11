using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<API.Models.House> Houses { get; set; }
        public DbSet<API.Models.Agency> Agencies { get; set; }
        public DbSet<API.Models.County> Counties { get; set; }
        public DbSet<API.Models.Realtor> Realtors { get; set; }
        public DbSet<API.Models.Category> Categories { get; set; }
        public DbSet<API.Models.Image> Images { get; set; }


    }
}