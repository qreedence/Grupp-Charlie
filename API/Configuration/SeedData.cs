
using API.Data;
using API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Configuration
{
    // Author: Mikaela Älgekrans
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Check for any agencies, categories, realtors and houses
                if (context.Agencies.Any() && context.Categories.Any() && context.Realtors.Any() && context.Houses.Any())
                {
                    return; // Objects has already been seeded
                }
                var env = serviceProvider.GetRequiredService<IWebHostEnvironment>();
                var path = Path.Combine(env.ContentRootPath, "Data", "Json", "seed-data.json");
                // Reads the json content and then deserialize it to objects
                var jsonString = System.IO.File.ReadAllText(path);
                if (jsonString != null)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-valluable type
                    Root root = System.Text.Json.JsonSerializer.Deserialize<Root>(jsonString);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-valluable type


                    // Adds the Category objects to the database
                    if (root?.Categories != null)
                    {
                        foreach (var category in root.Categories)
                        {
                            if (!context.Categories.Any(c => c.CategoryName == category.CategoryName))
                            {
                                context.Categories.Add(category);
                            }
                        }
                        context.SaveChanges();
                    }

                    // Adds the Agency objects to the database
                    if (root?.Agencies != null)
                    {
                        foreach (var agency in root.Agencies)
                        {
                            if (!context.Agencies.Any(a => a.NameOfAgency == agency.NameOfAgency))
                            {
                                context.Agencies.Add(agency);
                            }
                        }
                        context.SaveChanges();
                    }

                    // Get the Agency objects from the database
                    List<Agency> agenciesInDb = context.Agencies.ToList();

                    // Adds the Realtor objects to the database
                    if (root?.Realtors != null)
                    {
                        foreach (Realtor realtor in root.Realtors)
                        {
                            if (!context.Realtors.Any(r => r.Email == realtor.Email))
                            {
                                var hasher = new PasswordHasher<Realtor>();
                                realtor.PasswordHash = hasher.HashPassword(realtor, realtor.PasswordHash);
                                realtor.Agency = context.Agencies.FirstOrDefault(a => a.AgencyId == realtor.Agency.AgencyId);
                                context.Realtors.Add(realtor);
                            }
                        }
                        context.SaveChanges();
                    }
                    // Get the Realtor objects from the database
                    List<Realtor> realtorsInDb = context.Realtors.ToList();
                    // Get the Category objects from the database
                    List<Category> categoriesInDb = context.Categories.ToList();
                    // Get the County objects from the database
                    List<County> countiesInDb = context.Counties.ToList();
                    // Get the Municipality objects from the database
                    List<Municipality> municipalitiesInDb = context.Municipalities.ToList();

                    // Add the House objects to the database
                    // Check if countiesInDb is not null and contains elements
                    if (countiesInDb != null && countiesInDb.Any() && municipalitiesInDb != null && municipalitiesInDb.Any())
                    {
                        if (root?.Houses != null)
                        {
                            foreach (House house in root.Houses)
                            {
                                if (!context.Houses.Any(h => h.Adress == house.Adress))
                                {
                                    County county = context.Counties.FirstOrDefault(c => c.CountyName == house.County.CountyName);
                                    if (county != null)
                                    {
                                        house.County = county;
                                    }
                                    Municipality municipality = context.Municipalities.FirstOrDefault(c => c.MunicipalityName == house.Municipality.MunicipalityName);
                                    if (municipality != null)
                                    {
                                        house.Municipality = municipality;
                                    }
                                    Realtor realtor = context.Realtors.FirstOrDefault(r => r.Email == house.Realtor.Email);
                                    if (realtor != null)
                                    {
                                        house.Realtor = realtor;
                                    }
                                    house.Category = context.Categories.FirstOrDefault(a => a.CategoryId == house.Category.CategoryId);
                                    context.Houses.Add(house);
                                }
                            }
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        return; // Skip adding houses if there are no counties in countiesInDb
                    }

                }
            }
        }

        public class Root
        {
            public List<County> Counties { get; set; }
            public List<Municipality> Municipalities { get; set; }
            public List<Category> Categories { get; set; }
            public List<Agency> Agencies { get; set; }
            public List<Realtor> Realtors { get; set; }
            public List<House> Houses { get; set; }
        }
    }
}