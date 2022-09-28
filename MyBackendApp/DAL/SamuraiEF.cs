using Microsoft.EntityFrameworkCore;
using MyBackendApp.Models;

namespace MyBackendApp.DAL
{
    public class SamuraiEF : ISamurai
    {
        private AppDbContext _dbcontext;
        public SamuraiEF(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Delete(int id)
        {
            var deleteSamurai = GetById(id);
            if (deleteSamurai == null)
                throw new Exception($"Data samurai dengan id {id} tidak ditemukan");
            try
            {
                _dbcontext.Remove(deleteSamurai);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Samurai> GetAll()
        {
            var results = _dbcontext.Samurais.OrderBy(s => s.Name).ToList();
            /*var results = (from s in _dbcontext.Samurais
                          orderby s.Name ascending
                          select s).ToList();*/
            
            return results;
        }

        public IEnumerable<Samurai> GetAllWithQuote()
        {
            var results = _dbcontext.Samurais.Include(s => s.Quotes);
            return results;
        }

        public Samurai GetById(int id)
        {
            var result = _dbcontext.Samurais.FirstOrDefault(s=>s.Id==id);
            /*var result = (from s in _dbcontext.Samurais
                         where s.Id == id
                         select s).FirstOrDefault();*/

            if (result == null)
                throw new Exception($"Data id {id} tidak ditemukan");
            return result;
        }

        public IEnumerable<Samurai> GetByName(string name)
        {
            var results = _dbcontext.Samurais.Where(s => s.Name.Contains(name)).OrderBy(s => s.Name);
            return results;
        }

        public Samurai Insert(Samurai samurai)
        {
            try
            {
                _dbcontext.Samurais.Add(samurai);
                _dbcontext.SaveChanges();
                return samurai;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Samurai Update(Samurai samurai)
        {
            var updateSamurai = GetById(samurai.Id);
            if (updateSamurai == null) 
                throw new Exception($"Data samurai id {samurai.Id} tidak ditemukan");

            try
            {
                updateSamurai.Name = samurai.Name;
                _dbcontext.SaveChanges();
                return samurai;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
