using API.Data.Interfaces;
using API.Data.Repositories;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouse houseRepository;
        public HouseController(IHouse HouseRepository)
        {
            houseRepository = HouseRepository;
        }
        // GET: api/<HouseController>
        [HttpGet]
        public async Task<List<House>> Get()
        {
            return await houseRepository.GetAllAsync();
        }

        // GET api/<HouseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HouseController>
        [HttpPost]
        public async Task Post(House house)
        {
            await houseRepository.AddAsync(house);
        }

        // PUT api/<HouseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HouseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
