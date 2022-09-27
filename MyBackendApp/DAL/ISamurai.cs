using MyBackendApp.Models;

namespace MyBackendApp.DAL
{
    public interface ISamurai
    {
        public IEnumerable<Samurai> GetAll();
        public Samurai GetById(int id);
        public IEnumerable<Samurai> GetByName(string name);
        public Samurai Insert(Samurai samurai);
        public Samurai Update(int id,Samurai samurai);
        public void Delete(int id);
    }
}
