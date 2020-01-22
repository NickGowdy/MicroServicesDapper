using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using RandomPersonPicker.Domain.Models;

namespace RandomPersonPicker.Data.Repositories
{
    public class PersonRepository
    {
        private IDbConnection _dbConnection;
        private readonly string _connectionString = "Server=localhost;User Id = SA;Password=<YourStrong@Passw0rd>;Initial Catalog = RandomPersonPicker";

        public IEnumerable<Person> Get()
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                const string sql = @"SELECT * FROM Person";
                return _dbConnection.Query<Person>(sql);
            }
        }

        public Person Get(int personId)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                const string sql = @"SELECT * FROM Person WHERE PersonID = @personId";
                return _dbConnection.QueryFirstOrDefault<Person>(sql, new { personId });
            }
        }

        public long Insert(Person person)
        {
            using (_dbConnection = new SqlConnection(_connectionString))
            {
                return _dbConnection.Insert(person);

            }
        }
    }
}
