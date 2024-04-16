using API.Data.Interfaces;
using API.Data.Models;
using API.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        private readonly ICounty countyRepository;

        public CountyController(ICounty CountyRepository)
        {
            countyRepository = CountyRepository;
        }

        // GET: api/<ImageController>
        [HttpGet]
        public async Task<List<County>> Get()
        {
            return await countyRepository.GetAllAsync();
        }

        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public async Task<County> GetByIdAsync(int id)
        {
            return await countyRepository.GetByIdAsync(id);
        }

        // POST api/<ImageController>
        [HttpPost]
        public async Task Post(County county)
        {
            await countyRepository.AddAsync(county);
        }

        // PUT api/<ImageController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] County county)
        {
            await countyRepository.UpdateAsync(county);
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await countyRepository.DeleteAsync(id);
        }
    }
}
