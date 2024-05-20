using API.Data.Interfaces;
using API.Data.Repositories;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//Authors: Susanna Renström, Mikaela Älgekrans, Eden Yusof-Ioannidis

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

        [HttpGet]
        [Route("/api/house/getallsold")]
        public async Task<List<House>> GetSold()
        {
            return await houseRepository.GetAllSoldAsync();
        }

        // GET api/<HouseController>/5
        [HttpGet("{id}")]
        public async Task<House> GetByIdAsync(int id)
        {
            return await houseRepository.GetByIdAsync(id);
        }

        // POST api/<HouseController>
        [HttpPost]
        public async Task Post(House house)
        {
            await houseRepository.AddAsync(house);
        }

        // PUT api/<HouseController>/5
        [HttpPut("{id}")]
        public async Task Put(House house)
        {
            await houseRepository.UpdateAsync(house);
            
        }

        // DELETE api/<HouseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await houseRepository.DeleteAsync(id);
            
        }

        [HttpPut]
        [Route("sell/{id}")]
        public async Task Sell(int id)
        {
            await houseRepository.SellAsync(id);
        }

    } 
}

