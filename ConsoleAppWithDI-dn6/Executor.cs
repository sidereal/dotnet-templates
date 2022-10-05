using System;
using System.Threading.Tasks;

//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sidereal.Executor;

public class Executor
{
    private readonly ILogger<Executor> _logger;
    private readonly IConfiguration _config;

    public Executor(ILogger<Executor> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }
    public async Task RunAsync(int count = 1)
    {
        _logger.LogInformation("ASYNC RUNNING");
        if (count < 1) count = 1;
        for (int i = 1; i <= count; i++)
        {
            await Task.Delay(1000);
            _logger.LogInformation("ASYNC Count {count}", i);
        }
    }

    public void Run()
    {
        _logger.LogInformation("RUNNING");

    }
}