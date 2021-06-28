using Microsoft.Extensions.Configuration;
using SchoolApp.Infra.Helpers.Connections;

namespace SchoolApp.Infra.Repositories
{
    public abstract class BaseDbRepository
    {
        protected string _connectionString;
        protected abstract string ConnectionConfigName { get; }
        protected abstract string ProcedureConfigurationPath { get; }

        protected IConfigurationSection _procedures { get; }
        protected readonly IConfiguration _config;
        protected BaseConnectionHelper _helper;

        protected BaseDbRepository(IConfiguration config, BaseConnectionHelper helper)
        {
            _config = config;
            _helper = helper;

            _connectionString = _config.GetConnectionString(ConnectionConfigName);
            _procedures = _config.GetSection(ProcedureConfigurationPath);
        }
    }
}