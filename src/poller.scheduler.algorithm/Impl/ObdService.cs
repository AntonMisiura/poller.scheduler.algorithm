using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;

namespace poller.scheduler.algorithm.Impl
{
    public class ObdService : IObdService
    {
        private readonly ILogger<ObdService> _logger;
        private readonly AppSettings.AppSettings _config;

        public ObdService(ILogger<ObdService> logger,
            IOptions<AppSettings.AppSettings> config)
        {
            _config = config.Value;
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogWarning($"Wow! We are now in test service of {_config.Title}");
        }
    }
}
