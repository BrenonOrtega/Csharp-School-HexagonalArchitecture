using System.Data;

namespace SchoolApp.Infra.Helpers.Connections
{
    public interface IConnectionHelper<T> where T : IDbConnection
    {
        T GetConnection(string connectionString);
    }
}