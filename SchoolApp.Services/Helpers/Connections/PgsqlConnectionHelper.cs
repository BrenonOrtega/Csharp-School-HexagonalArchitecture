using Npgsql;

namespace SchoolApp.Services.Helpers.Connections
{
    public class PgsqlConnectionHelper : BaseConnectionHelper
    {
        public override NpgsqlConnection GetConnection(string connectionString)
        {
            var connection = new NpgsqlConnection(connectionString);
            return connection;
        }
    }
}