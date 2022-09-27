using MyBackendApp.Models;

namespace MyBackendApp.DAL
{
    public class SamuraiDAL : ISamurai
    {
        private readonly IConfiguration _config;
        public SamuraiDAL(IConfiguration config)
        {
            _config = config;
        }
        private string GetConn()
        {
            return _config.GetConnectionString("SamuraiConnection");
        }

        public IEnumerable<Samurai> GetAll()
        {
            throw new NotImplementedException();
        }

        public Samurai GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
