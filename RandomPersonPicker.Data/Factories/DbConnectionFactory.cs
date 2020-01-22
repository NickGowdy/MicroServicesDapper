using System.Data;
using System.Data.SqlClient;
using RandomPersonPicker.Interfaces.Factories;

namespace RandomPersonPicker.Data.Factories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateDbConnection(string connectionstring)
        {
            return new SqlConnection(connectionstring);
        }
    }
}

