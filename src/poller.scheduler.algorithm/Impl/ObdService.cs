using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;

namespace poller.scheduler.algorithm.Impl
{
    public class ObdService : IObdService
    {
        private readonly AppSettings _config;
        private readonly ILogger<ObdService> _logger;

        public ObdService(ILogger<ObdService> logger,
            IOptions<AppSettings> config)
        {
            _logger = logger;
            _config = config.Value;
        }

        public void Run()
        {
            _logger.LogWarning($"Wow! We are now in test service of {_config.Title}");
        }
    }
}
