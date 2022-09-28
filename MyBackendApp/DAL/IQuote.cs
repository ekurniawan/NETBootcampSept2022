using MyBackendApp.Models;

namespace MyBackendApp.DAL
{
    public interface IQuote
    {
        public IEnumerable<Quote> GetAll();
        public Quote GetById(int id);
        public IEnumerable<Quote> GetByName(string name);
        public Quote Insert(Quote quote);
        public Quote Update(Quote quote);
        public void Delete(int id);
    }
}
