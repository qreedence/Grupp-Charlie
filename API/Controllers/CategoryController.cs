using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    //Author; Susanna
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory categoryReository;

        public CategoryController(ICategory categoryReository)
        {
            this.categoryReository = categoryReository;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<Category>> GetAllAsync()
        {
           return await categoryReository.GetAllAsync();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<Category> GetById(int id)
        {
            return await categoryReository.GetByIdAsync(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task Post(Category category)
        {
            await categoryReository.AddAsync(category); 
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(Category category)
        {
            await categoryReository.UpdateAsync(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await categoryReository.DeleteAsync(id);
        }
    }
}
