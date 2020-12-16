using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
        _logger.LogInformation("(NOT) RUNNING ASYNC");

    }

    public void Run()
    {
        _logger.LogInformation("RUNNING");

    }
}