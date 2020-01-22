using System.Data;
using RandomPersonPicker.Interfaces.Factories;

namespace RandomPersonPicker.Data.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IDbConnection _dbConnection;

        public BaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnection = dbConnectionFactory.CreateDbConnection("");
        }
    }
}
