using System.Threading.Tasks;

//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sidereal.Executor
{
    public class Executor
    {
        private readonly ILogger<Executor> _logger;
        private readonly IConfiguration _config;

        public Executor(ILogger<Executor> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }
        public async Task RunAsync()
        {
            Task task = new(() => _logger.LogError("PRETENDING TO RUN ASYNC"));
            task.Start();
            await task;
        }

        public void Run()
        {
            _logger.LogInformation("RUNNING");

        }
    }
}