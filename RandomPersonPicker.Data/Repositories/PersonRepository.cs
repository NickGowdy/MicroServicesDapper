using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using RandomPersonPicker.Domain.Models;

namespace RandomPersonPicker.Data.Repositories
{
    public class PersonRepository
    {
        private IDbConnection _dbConnection;
        private readonly string _connectionString = "Server=localhost;User Id = SA;Password=<YourStrong@Passw0rd>;Initial Catalog = RandomPersonPicker";

        public async Task<IEnumerable<Person>> Get()
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                const string sql = @"SELECT * FROM Person";
                return await _dbConnection.QueryAsync<Person>(sql);
            }
        }

        public async Task<Person> Get(int personId)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                const string sql = @"SELECT * FROM Person WHERE PersonID = @personId";
                return await _dbConnection.QueryFirstOrDefaultAsync<Person>(sql, new { personId });
            }
        }

        public async Task<long> Insert(Person person)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                return await _dbConnection.InsertAsync(person);

            }
        }
    }
}
