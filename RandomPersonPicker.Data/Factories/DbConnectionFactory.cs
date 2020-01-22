using System.Data;
using System.Data.SqlClient;
using RandomPersonPicker.Interfaces.Factories;

namespace RandomPersonPicker.Data.Factories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        protected readonly string ConnectionString = "Server=localhost;User Id = SA;Password=<YourStrong@Passw0rd>;Initial Catalog = RandomPersonPicker";

        public IDbConnection CreateDbConnection(string connectionstring) => new SqlConnection(connectionstring);
    }
}
