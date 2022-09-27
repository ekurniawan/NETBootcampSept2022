using MyBackendApp.Models;

namespace MyBackendApp.DAL
{
    public interface ISamurai
    {
        public IEnumerable<Samurai> GetAll();
        public Samurai GetById(int id);
    }
}
