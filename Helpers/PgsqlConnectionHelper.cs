using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FirstDataAccess.Helpers
{
    class PgsqlConnectionHelper : IConnectionHelper
    {
        private IConfiguration _config;
        private ILogger<PgsqlConnectionHelper> _logger;
        public PgsqlConnectionHelper(IConfiguration config, ILogger<PgsqlConnectionHelper> logger)
        {
            _config = config;
            _logger = logger;
        }

        public IDbConnection GetDbConnection(string name)
        {
            var cnnString = _config.GetConnectionString(name);
            var connection = new NpgsqlConnection(cnnString);
            _logger.LogInformation(cnnString);
            return connection;
        }

    }
}