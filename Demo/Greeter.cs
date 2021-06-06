using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace firstDataAccess.Demo
{
    
    public class Greeter : IGreeter
    {
        private readonly ILogger<Greeter> _logger;
        private readonly IConfiguration _config;

        public Greeter(ILogger<Greeter> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public void EnumerateFromAppSettings()
        {
            Enumerable.Range(1, _config.GetValue<int>("Loop Times")).ToList()
                .ForEach(i => _logger.LogInformation("The number is {loopNumber}", i));
        }

        public void Greet(IEnumerable<object> objs)
        {
            foreach(var obj in objs)
            {
                _logger.LogInformation("Hello {objName}", obj);
            }
        }
    }
}