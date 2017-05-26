using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;

namespace poller.scheduler.algorithm.Impl
{
    public class App
    {
        private readonly Car _config;
        private readonly ILogger<App> _logger;
        private readonly IObdService _obdConnectionService;

        public App(ILogger<App> logger,
            IOptions<Car> config,
            IObdService obdConnectionService)
        {
            _logger = logger;
            _config = config.Value;
            _obdConnectionService = obdConnectionService;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.Pids}");

            _obdConnectionService.Run();

            Console.ReadKey();
        }
    }
}
