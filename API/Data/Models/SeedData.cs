using Microsoft.EntityFrameworkCore;

namespace API.Data.Models
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new ApplicationDbContext(
				serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
			{
				//Look for any agencies
				if (context.Agencies.Any())
				{
					return; //DB has been seeded
				}
				//get the json file from wwwroot folder
				var env = serviceProvider.GetRequiredService<IWebHostEnvironment>();
				var path = Path.Combine(env.ContentRootPath, "Data", "Json", "seed-data.json");
				//read the json content and then deserialize it to object,
				var jsonString = System.IO.File.ReadAllText(path);
				if (jsonString != null)
				{
#pragma warning disable CS8600 // Converting null literal or possible null value to non-valluable type
					Root root = System.Text.Json.JsonSerializer.Deserialize<Root>(jsonString);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-valluable type


					// Add the Category objects to the database
					if (root?.Categories != null)
					{
						context.Categories.AddRange(root.Categories);
						context.SaveChanges();
					}

					// Add the Agency objects to the database
					if (root?.Agencies != null)
					{
						context.Agencies.AddRange(root.Agencies);
						context.SaveChanges();
					}

					// Get the Agency objects from the database
					List<Agency> agenciesInDb = context.Agencies.ToList();

					// Replace the Agency property in each Realtor object with the corresponding Agency object from the database
					if (root?.Realtors != null)
					{
						foreach (Realtor realtor in root.Realtors)
						{
							realtor.Agency = agenciesInDb.FirstOrDefault(a => a.AgencyId == realtor.Agency.AgencyId);
						}

						// Add the Realtor objects to the database
						context.Realtors.AddRange(root.Realtors);
						context.SaveChanges();
					}
				}
			}
		}
		public class Root
		{
			public List<Category> Categories { get; set; }
			public List<Agency> Agencies { get; set; }
			public List<Realtor> Realtors { get; set; }

		}
	}
}
