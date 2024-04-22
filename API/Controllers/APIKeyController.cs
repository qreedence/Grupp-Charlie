using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

//Author: Eden Yusof-Ioannidis

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIKeyController : ControllerBase
    {
        private readonly IAPIKey apiKeyRepository;
        public APIKeyController(IAPIKey apiKeyRepository)
        {
            this.apiKeyRepository = apiKeyRepository;
        }
        // GET: api/<RealtorController>
        [HttpGet]
        public async Task<APIKey> GetAsync()
        {
            return await apiKeyRepository.GetAsync();
        }

        [HttpPost]
        public async Task AddAsync(APIKey apiKey)
        {
            await apiKeyRepository.AddAsync(apiKey);
        }
    }
}
