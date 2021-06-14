using System.Data.Common;

namespace SchoolApp.Infra.Helpers.Connections
{
    public abstract class BaseConnectionHelper : IConnectionHelper<DbConnection>
    {
        public abstract DbConnection GetConnection(string connectionString);
    }
}