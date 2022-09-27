using MyBackendApp.Models;
using System.Data.SqlClient;

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
            using(SqlConnection conn =new SqlConnection(GetConn()))
            {
                List<Samurai> listSamurai = new List<Samurai>();
                string strSql = @"select * from Samurais order by Name asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        listSamurai.Add(new Samurai()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = dr["Name"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return listSamurai;
            }
        }

        public Samurai GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                Samurai samurai = new Samurai();
                string strSql = @"select * from Samurais where Id=@Id";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    dr.Read();
                    samurai.Id = Convert.ToInt32(dr["Id"]);
                    samurai.Name = dr["Name"].ToString();
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();

                return samurai;
            }
        }
    }
}
