using MyBackendApp.Models;

namespace MyBackendApp.DAL
{
    public class QuoteEF : IQuote
    {
        private AppDbContext _dbcontext;
        public QuoteEF(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quote> GetAll()
        {
            var quotes = _dbcontext.Quotes;
            return quotes;
        }

        public Quote GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quote> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Quote Insert(Quote quote)
        {
            throw new NotImplementedException();
        }

        public Quote Update(Quote quote)
        {
            throw new NotImplementedException();
        }
    }
}
