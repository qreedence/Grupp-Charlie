using API.Data.Interfaces;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

//Author: Eden Yusof-Ioannidis

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("counties")]
        public IActionResult GetAllCounties()
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
        [HttpGet("municipalities")]
        public IActionResult GetAllMunicipalities()
        {
            try
            {
                string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Json", "municipalities.json");
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



