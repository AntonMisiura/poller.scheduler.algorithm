using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl.Entities;

namespace poller.scheduler.algorithm.Impl.Service
{
    public class ObdService : IObdService
    {
        private readonly Car _config;
        private readonly ILogger<ObdService> _logger;

        public ObdService(ILogger<ObdService> logger,
            IOptions<Car> config)
        {
            _logger = logger;
            _config = config.Value;
        }

        public void Run()
        {
            _logger.LogWarning($"Wow! We are now in test service of {_config.Pids}");
        }
    }
}
