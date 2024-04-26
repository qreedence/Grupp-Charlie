using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Json", "counties.json");
                string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
                return Content(jsonContent, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}



