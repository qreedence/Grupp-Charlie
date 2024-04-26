using API.Data.Interfaces;
using API.Data.Models;
using API.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Author: Eden Yusof-Ioannidis

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipality municipalityRepository;

        public MunicipalityController(IMunicipality MunicipalityRepository)
        {
            municipalityRepository = MunicipalityRepository;
        }

        // GET: api/<ImageController>
        [HttpGet]
        public async Task<List<Municipality>> Get()
        {
            return await municipalityRepository.GetAllAsync();
        }

        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public async Task<Municipality> GetByIdAsync(int id)
        {
            return await municipalityRepository.GetByIdAsync(id);
        }

        // POST api/<ImageController>
        [HttpPost]
        public async Task Post(Municipality municipality)
        {
            await municipalityRepository.AddAsync(municipality);
        }

        // PUT api/<ImageController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] Municipality municipality)
        {
            await municipalityRepository.UpdateAsync(municipality);
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await municipalityRepository.DeleteAsync(id);
        }
    }
}
