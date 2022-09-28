using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendApp.DAL;
using MyBackendApp.DTO;
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
        public IEnumerable<SamuraiGetDTO> Get()
        {
            List<SamuraiGetDTO> lstSamuraiGetDto = new List<SamuraiGetDTO>();
            var results = _samurai.GetAll();
            foreach(var s in results)
            {
                lstSamuraiGetDto.Add(new SamuraiGetDTO
                {
                    Id = s.Id,
                    Name = s.Name
                });
            }
            return lstSamuraiGetDto;
        }

        [HttpGet("{id}")]
        public SamuraiGetDTO Get(int id)
        {
            var result = _samurai.GetById(id);
            var samuraiGetDto = new SamuraiGetDTO
            {
                Name = result.Name
            };
            return samuraiGetDto;
        }

        [HttpGet("ByName")]
        public IEnumerable<SamuraiGetDTO> GetByName(string name)
        {
            List<SamuraiGetDTO> listSamuraiGetDto = new List<SamuraiGetDTO>();
            var results = _samurai.GetByName(name);
            foreach(var r in results)
            {
                listSamuraiGetDto.Add(new SamuraiGetDTO
                {
                    Name = r.Name
                });
            }
            return listSamuraiGetDto;
        }

        [HttpPost]
        public IActionResult Post(SamuraiAddDTO samuraiDto)
        {
            try
            {
                var samurai = new Samurai
                {
                    Name = samuraiDto.Name
                };

                var newSamurai = _samurai.Insert(samurai);
                return CreatedAtAction("Get", new { id = newSamurai.Id }, newSamurai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        public IActionResult Put(Samurai samurai)
        {
            try
            {
                var editSamurai = _samurai.Update(samurai);
                return Ok(editSamurai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _samurai.Delete(id);
                return Ok($"Delete id {id} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
