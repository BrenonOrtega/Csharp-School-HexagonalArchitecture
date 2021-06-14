
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SchoolApp.Infra.Repositories.PlainFiles
{
    public abstract class BasePlainFileProperties
    {
        protected readonly IConfiguration _config;
        protected readonly ILogger _logger; 

        public BasePlainFileProperties(IConfiguration config, ILogger logger)
        {
            _config = config;
            _logger = logger;
        }
    }
}