﻿using API.Data.Models;
namespace API.Data.Interfaces
{
    public interface IHouse
    {
        public Task AddAsync(House house);
        public Task<List<House>> GetAllAsync();
        public Task<List<House>> GetAllSoldAsync();
        public Task UpdateAsync(House house);
        public Task DeleteAsync (int id);
        public Task<House> GetByIdAsync(int id);
        public Task SellAsync(int id);
    }
}
