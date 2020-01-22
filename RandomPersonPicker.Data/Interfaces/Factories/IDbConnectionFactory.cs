using System.Data;

namespace RandomPersonPicker.Interfaces.Factories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(string connectionstring);
    }
}
