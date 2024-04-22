using API.Data.Interfaces;
using API.Data.Models;
using API.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Author: Mikaela Älgekrans

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImage imageRepository;

        public ImageController(IImage ImageRepository)
        {
            imageRepository = ImageRepository;
        }

        // GET: api/<ImageController>
        [HttpGet]
        public async Task<List<Image>> Get()
        {
            return await imageRepository.GetAllAsync();
        }

        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public async Task<Image> GetByIdAsync(int id)
        {
            return await imageRepository.GetByIdAsync(id);
        }

        // POST api/<ImageController>
        [HttpPost]
        public async Task Post(Image image)
        {
            await imageRepository.AddAsync(image);
        }

        // PUT api/<ImageController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] Image image)
        {
            await imageRepository.UpdateAsync(image);
        }

        // DELETE api/<ImageController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await imageRepository.DeleteAsync(id);
        }
    }
}
