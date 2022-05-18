using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using zad3.Models;

namespace zad3.Services
{
    public class DbService : IDbService
    {
        private const string ConnString = "Data Source=db-mssql;Initial Catalog=jd;Integrated Security=True";
        
        public async Task<IList<Animal>> GetAnimalListAsync()
        {
            List<Animal> result = new();

            string sql = "SELECT * FROM Book";

            await using SqlConnection connection = new(ConnString);

            await using SqlCommand comm = new(sql, connection);

            await connection.OpenAsync();

            await using SqlDataReader dr = await comm.ExecuteReaderAsync();

            /*
             * 
            if (!dr.HasRows)
            {
                // Logika gdy w bazie nic nie ma
            }
            */

            while (await dr.ReadAsync())
            {
                result.Add(new Animal()
                {
                    IdAnimal = int.Parse((string)dr["IdAnimal"]),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString(),
                });
            }

            await connection.CloseAsync();

            return result;
        }
    }
}