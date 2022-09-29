using AutoMapper;
using MyBackendApp.DTO;
using MyBackendApp.Models;

namespace MyBackendApp.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
        {
            CreateMap<QuoteAddDTO, Quote>();
            CreateMap<Quote, QuoteGetDTO>();
            CreateMap<Quote, QuotesWithSamuraiDto>();
            CreateMap<Samurai, SamuraiGetDTO>();
            CreateMap<SamuraiAddDTO, Samurai>();
            CreateMap<QuoteAddTextDto, Quote>();
         
            CreateMap<Samurai, SamuraiWithQuoteDTO>();
            CreateMap<SamuraiAddWithQuotesDto,Samurai>();
        }
    }
}
