using API.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Data.Repositories;
using API.Data.Models;

//Author: Susanna Renström
namespace API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly IAgency agencyRepository;
        public AgencyController(IAgency AgencyRepository)
        {
            agencyRepository = AgencyRepository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Agency>> GetAllAsync()
        {
            return await agencyRepository.GetAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Agency> GetByIdAsync(int id)
        {
            return await agencyRepository.GetByIdAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post(Agency agency)
        {
            await agencyRepository.AddAsync(agency);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task Put(Agency agency)
        {
            await agencyRepository.UpdateAsync(agency);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await agencyRepository.DeleteAsync(id);
                    
        }
    }
}
