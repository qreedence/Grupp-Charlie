using API.Data.Interfaces;
using API.Data.Models;
using API.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtorController : ControllerBase
    {
        private readonly IRealtor realtorRepository;

        public RealtorController(IRealtor RealtorRepository)
        {
            realtorRepository = RealtorRepository;
        }
        // GET: api/<RealtorController>
        [HttpGet]
        public async Task<List<Realtor>> GetAllAsync()
        {
            return await realtorRepository.GetAllAsync();
        }

        // GET api/<RealtorController>/5
        [HttpGet("{id}")]
        public async Task<Realtor> GetByIdAsync(string id)
        {
            return await realtorRepository.GetByIdAsync(id);
        }

        // POST api/<RealtorController>
        [HttpPost]
        public async Task AddAsync(Realtor realtor)
        {
            await realtorRepository.AddAsync(realtor);
        }

        // PUT api/<RealtorController>/5
        [HttpPut("{id}")]
        public async Task EditAsync(Realtor realtor)
        {
            await realtorRepository.EditAsync(realtor);          
        }

        // DELETE api/<RealtorController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await realtorRepository.DeleteAsync(id);
        }
    }
}
