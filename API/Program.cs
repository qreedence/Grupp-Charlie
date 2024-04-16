using API.Data;
using API.Data.Interfaces;
using API.Data.Repositories;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            builder.Services.AddTransient<IAgency, AgencyRepository>();
            builder.Services.AddTransient<ICategory, CategoryRepository>();
            builder.Services.AddTransient<ICounty, CountyRepository>();
            builder.Services.AddTransient<IHouse, HouseRepository>();
            builder.Services.AddTransient<IImage, ImageRepository>();
            builder.Services.AddTransient<IRealtor, RealtorRepository>();

            var app = builder.Build();
            //La till denna för att lösa "loading" problemet
            app.UseCors(policy =>
            policy.WithOrigins("https://localhost:7023", "https://localhost:7256")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "x-custom-header")
                .AllowCredentials());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }


}
