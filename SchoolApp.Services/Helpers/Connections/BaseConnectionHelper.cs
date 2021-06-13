using System.Data;
using SchoolApp.Infra.Helpers.Connection;

namespace SchoolApp.Services.Helpers.Connections
{
    public abstract class BaseConnectionHelper : IConnectionHelper<IDbConnection>
    {
        public abstract IDbConnection GetConnection(string connectionString);
    }
}