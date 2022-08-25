using System.Reflection;

namespace MinimalApi.Demo
{
    public class DemoService
    {
        private readonly ILogger<DemoService> _logger;
        private readonly IConfiguration _config;

        public DemoService(ILogger<DemoService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            var className = GetType().Name;

            _logger.LogInformation("Service {name} started", className);
        }

        public void DoSomething(string message)
        {
            var className = GetType().Name;
            var methodName = MethodBase.GetCurrentMethod()?.Name;

            _logger.LogInformation("Message: {message} logged in {name}.{method}", message, className, methodName);
        }
    }
}
