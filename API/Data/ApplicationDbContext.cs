using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }


    }
}