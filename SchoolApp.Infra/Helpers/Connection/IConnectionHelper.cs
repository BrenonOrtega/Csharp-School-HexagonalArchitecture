using System.Data;

namespace SchoolApp.Infra.Helpers.Connection
{
    public interface IConnectionHelper<T> where T : IDbConnection
    {
        T GetConnection(string connectionString);
    }
}