namespace MinimalApi.Demo
{
    public class DummyService
    {
        private readonly ILogger<DummyService> _logger;
        private readonly IConfiguration _config;

        public DummyService(ILogger<DummyService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _logger.LogInformation("DummyService started");
        }

        public void DoSomething(string message)
        {
            _logger.LogInformation("Logged in DummyService: {message}", message);
        }
    }
}
