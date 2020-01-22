using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using RandomPersonPicker.Data.Factories;
using RandomPersonPicker.Data.Interfaces.Repositories;
using RandomPersonPicker.Domain.Models;

namespace RandomPersonPicker.Data.Repositories
{
    public class PersonRepository : DbConnectionFactory, IPersonRepository
    {
        public async Task<IEnumerable<Person>> Get()
        {
            using (var SqlConnection = CreateDbConnection(ConnectionString))
            {
                const string Sql = @"SELECT * FROM Person";
                return await SqlConnection.QueryAsync<Person>(Sql);
            }
        }

        public async Task<Person> Get(int personId)
        {
            using (var SqlConnection = CreateDbConnection(ConnectionString))
            {
                const string Sql = @"SELECT * FROM Person WHERE PersonID = @personId";
                return await SqlConnection.QueryFirstOrDefaultAsync<Person>(Sql, new { personId });
            }
        }

        public async Task<long> Insert(Person person)
        {
            using (var SqlConnection = CreateDbConnection(ConnectionString))
            {
                return await SqlConnection.InsertAsync(person);
            }
        }
    }
}