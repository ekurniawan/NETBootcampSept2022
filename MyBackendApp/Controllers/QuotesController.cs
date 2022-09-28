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
                var quoteDto = new QuotesWithSamuraiDto();
                quoteDto.Id = r.Id;
                quoteDto.Text = r.Text;
                quoteDto.Samurai = new SamuraiGetDTO();
                quoteDto.SamuraiId = r.SamuraiId;
                quoteDto.Samurai.Name = r.Samurai.Name;
                quoteDto.Samurai.Id = r.Samurai.Id;

                lstQuotesWithSamuraiDto.Add(quoteDto);
            }
            return lstQuotesWithSamuraiDto;
        }

        [HttpGet("Samurai/{samuraiId}")]
        public IEnumerable<QuotesWithSamuraiDto> GetAll(int samuraiId)
        {
            List<QuotesWithSamuraiDto> lstQuotesWithSamuraiDto = new List<QuotesWithSamuraiDto>();
            var results = _quotes.GetAll(samuraiId);
            foreach (var r in results)
            {
                var quoteDto = new QuotesWithSamuraiDto();
                quoteDto.Id = r.Id;
                quoteDto.Text = r.Text;
                quoteDto.Samurai = new SamuraiGetDTO();
                quoteDto.SamuraiId = r.SamuraiId;
                quoteDto.Samurai.Name = r.Samurai.Name;
                quoteDto.Samurai.Id = r.Samurai.Id;

                lstQuotesWithSamuraiDto.Add(quoteDto);
            }
            return lstQuotesWithSamuraiDto;
        }
    }
}
