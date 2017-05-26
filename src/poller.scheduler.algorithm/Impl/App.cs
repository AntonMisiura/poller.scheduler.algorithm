using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl.Entities;
using poller.scheduler.algorithm.Impl.Service;

namespace poller.scheduler.algorithm.Impl
{
    public class App
    {
        private readonly SerialPortSettings _settings;
        private readonly Car _config;
        private readonly ILogger<App> _logger;
        private readonly IObdService _obdConnectionService;

        public App(ILogger<App> logger,
            IOptions<Car> config,
            IOptions<SerialPortSettings> settings,
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

            var manager = new ObdManager();
            manager.Execute();

            _obdConnectionService.Run();
            Console.ReadKey();
        }
    }
}
