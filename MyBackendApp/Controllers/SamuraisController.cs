using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendApp.Models;

namespace MyBackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        [HttpGet]
        public Samurai Get()
        {
            Samurai samurai1 = new Samurai()
            {
                Id = 1,Name="Tanjiro Kamado"
            };
            return samurai1;
        }
    }
}
