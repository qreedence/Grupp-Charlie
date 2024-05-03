using API.Data;
using API.Data.Interfaces;
using API.Data.Repositories;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            // For Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            // Adding Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
            builder.Services.AddTransient<IAgency, AgencyRepository>();
            builder.Services.AddTransient<ICategory, CategoryRepository>();
            builder.Services.AddTransient<ICounty, CountyRepository>();
            builder.Services.AddTransient<IMunicipality, MunicipalityRepository>();
            builder.Services.AddTransient<IHouse, HouseRepository>();
            builder.Services.AddTransient<IImage, ImageRepository>();
            builder.Services.AddTransient<IRealtor, RealtorRepository>();
            builder.Services.AddTransient<IAPIKey, APIKeyRepository>();



            var app = builder.Build();
            //La till denna för att lösa "loading" problemet
            app.UseCors(policy =>
            policy.WithOrigins("https://localhost:7023", "https://localhost:7256")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "x-custom-header")
                .AllowCredentials());

			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				SeedData.Initialize(services);
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }


}
