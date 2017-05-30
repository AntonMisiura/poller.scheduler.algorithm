using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl.Algorithm;
using poller.scheduler.algorithm.Impl.Command;
using poller.scheduler.algorithm.Impl.Connection;
using poller.scheduler.algorithm.Impl.Entities;

namespace poller.scheduler.algorithm.Impl
{
    public class App
    {
        private IObdCommand[] _commands;
        private IObdConnection _connection;
        private readonly IOptions<Car> _config;
        private readonly IOptions<AppSettings> _settings;
        private readonly ILogger<ObdSerialPortConnection> _logger;
        private List<PidObj> _list;

        public App(ILogger<ObdSerialPortConnection> logger,
            IOptions<Car> config,
            IOptions<AppSettings> settings)
        {
            _logger = logger;
            _config = config;
            _settings = settings;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.Value.Pids}");
            _connection = new ObdSerialPortConnection(_logger, _settings);
            _connection.Open();

            _commands = new IObdCommand[]
            {
                new SupportedPidsCommand(),
                new EngineRpmCommand(),
                new MassAirflowCommand(),
                new EngineTemperatureCommand(),
                new ThrottlePositionCommand(),
                new RoadSpeedCommand()
            };

            //converting Car List to PidObject List with percents
            var configPids = _config.Value.Pids;
            var pidObjs = configPids.Select(pid => new PidObj(pid.Name, pid.Code, pid.Priority)).ToList();

            //start algorithm, get output queue 
            var poller = new Poller(pidObjs, "88198000");

            _list = poller._queue;

            //foreach (var pid in _list)
            //{
            //    if (pid.Code == "0C")
            //        new EngineRpmCommand();
            //    if (pid.Code == "0D")
            //        new RoadSpeedCommand();
            //    if (pid.Code == "11")
            //        new ThrottlePositionCommand();
            //    if (pid.Code == "05")
            //        new EngineTemperatureCommand();
            //    if (pid.Code == "10")
            //        new MassAirflowCommand();
            //}

            Execute();
        }

        public string Execute()
        {
            var response = string.Empty;
            foreach (var command in _commands)
            {
                command.Execute(_connection);
                response += $"{command}\n";
                Console.ReadKey();
            }

            _connection.Close();

            return response;
        }
    }
}
