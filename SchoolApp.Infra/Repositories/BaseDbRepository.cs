using Microsoft.Extensions.Configuration;
using SchoolApp.Infra.Helpers.Connections;

namespace SchoolApp.Infra.Repositories
{
    public abstract class BaseDbRepository
    {
        protected string _connectionString;
        public abstract string ConnectionConfigName { get; }
        public abstract string ProcedureConfigurationPath { get; }

        protected IConfigurationSection _procedures { get; }
        protected readonly IConfiguration _config;
        protected BaseConnectionHelper _helper;

        public BaseDbRepository(IConfiguration config, BaseConnectionHelper helper)
        {
            _config = config;
            _helper = helper;
            
            _connectionString = _config.GetConnectionString(ConnectionConfigName);
            _procedures = _config.GetSection(ProcedureConfigurationPath);
        }
    }
}