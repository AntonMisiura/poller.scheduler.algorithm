using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl.Entities;

namespace poller.scheduler.algorithm.Impl
{
    public class App
    {
        private readonly Car _config;
        private readonly AppSettings _settings;
        private readonly ILogger<App> _logger;
        private readonly IObdService _obdConnectionService;

        public App(ILogger<App> logger,
            IOptions<Car> config,
            IOptions<AppSettings> settings,
            IObdService obdConnectionService)
        {
            _logger = logger;
            _config = config.Value;
            _settings = settings.Value;
            _obdConnectionService = obdConnectionService;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.Pids} {_settings.PortName}");

            _obdConnectionService.Run();
            Console.ReadKey();
        }
    }
}
