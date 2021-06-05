using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FirstDataAccess.Helpers
{
    class PgsqlConnectionHelper : IConnectionHelper
    {
        public string CnnStringName { get => "postgres";}
        private IConfiguration _config;
        private ILogger<PgsqlConnectionHelper> _logger;
        
        public PgsqlConnectionHelper(IConfiguration config, ILogger<PgsqlConnectionHelper> logger)
        {
            _config = config;
            _logger = logger;
        }

        public IDbConnection GetDbConnection()
        {
            var cnnString = _config.GetConnectionString(CnnStringName);
            var connection = new NpgsqlConnection(cnnString);
            return connection;
        }

    }
}