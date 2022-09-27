using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendApp.DAL;
using MyBackendApp.Models;

namespace MyBackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samurai;
        public SamuraisController(ISamurai samurai)
        {
            _samurai = samurai;
        }

        [HttpGet]
        public IEnumerable<Samurai> Get()
        {
            var results = _samurai.GetAll();
            return results;
        }

        [HttpGet("{id}")]
        public Samurai Get(int id)
        {
            return _samurai.GetById(id);
        }

        [HttpGet("ByName")]
        public IEnumerable<Samurai> GetByName(string name)
        {
            return _samurai.GetByName(name);
        }

        [HttpPost]
        public IActionResult Post(Samurai samurai)
        {
            try
            {
                var newSamurai = _samurai.Insert(samurai);
                return CreatedAtAction("Get", new { id = newSamurai.Id }, newSamurai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
