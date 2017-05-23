using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;
using RJCP.IO.Ports;

namespace poller.scheduler.algorithm.Impl
{
    public class App
    {
        private readonly AppSettings.AppSettings _config;
        private readonly ILogger<App> _logger;
        private readonly IObdService _obdConnectionService;
        private SerialPortStream Port;

        public App(IObdService obdConnectionService,
            IOptions<AppSettings.AppSettings> config,
            ILogger<App> logger)
        {
            _obdConnectionService = obdConnectionService;
            _config = config.Value;
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.Title}");
            Port = new SerialPortStream(_config.PortName, _config.BaudRate, _config.DataBits, _config.Parity, _config.StopBits);
            Port.Open();
            Console.WriteLine("Serial port is opened.");

            _obdConnectionService.Run();
            Console.ReadKey();
        }
    }
}
