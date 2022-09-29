using MyBackendApp.Models;

namespace MyBackendApp.DAL
{
    public interface ISamurai
    {
        public IEnumerable<Samurai> GetAll();
        public IEnumerable<Samurai> GetAllWithQuote();
        public Samurai GetById(int id);
        public IEnumerable<Samurai> GetByName(string name);
        public Samurai Insert(Samurai samurai);
        public Samurai Update(Samurai samurai);
        public void Delete(int id);

        //mendaftarkan samurai yang sudah ada ke battle yang sudah ada
        public void AddSamuraiToBattle(int samuraiId, int battleId);
    }
}
