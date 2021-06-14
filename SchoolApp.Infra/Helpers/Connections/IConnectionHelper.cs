using System.Data.Common;

namespace SchoolApp.Infra.Helpers.Connections
{
    public interface IConnectionHelper<T> where T : DbConnection
    {
        T GetConnection(string connectionString);
    }
}