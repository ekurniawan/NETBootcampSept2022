using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackendApp.DAL;
using MyBackendApp.DTO;
using MyBackendApp.Models;

namespace MyBackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private IQuote _quotes;
        public QuotesController(IQuote quotes)
        {
            _quotes = quotes;
        }

        [HttpGet]
        public IEnumerable<QuotesWithSamuraiDto> GetAll()
        {
            List<QuotesWithSamuraiDto> lstQuotesWithSamuraiDto = new List<QuotesWithSamuraiDto>();
            var results = _quotes.GetAll();
            foreach(var r in results)
            {
                lstQuotesWithSamuraiDto.Add(new QuotesWithSamuraiDto
                {
                    Id = r.Id,
                    Text = r.Text,
                    SamuraiId = r.SamuraiId,
                    SamuraiName = r.Samurai.Name
                });
            }
            return lstQuotesWithSamuraiDto;
        }
    }
}
