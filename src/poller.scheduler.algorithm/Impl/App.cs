using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl.Algorithm;
using poller.scheduler.algorithm.Impl.Connection;
using poller.scheduler.algorithm.Impl.Entities;

namespace poller.scheduler.algorithm.Impl
{
    public class App
    {
        private List<PidObj> _pidObjectsList;
        private IObdConnection _connection;
        private readonly IOptions<Car> _config;
        private readonly IOptions<AppSettings> _settings;
        private readonly ILogger<ObdSerialPortConnection> _logger;
        private List<IObdCommand> _commands = new List<IObdCommand>();

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

            //converting Car List to PidObject List with percents
            var configPids = _config.Value.Pids;
            var pidObjs = configPids.Select(pid => new PidObj(pid.Name, pid.Code, pid.Priority)).ToList();

            //start algorithm, get output queue 
            var poller = new Poller(pidObjs, "88198000");

            _pidObjectsList = poller._queue;

            foreach (var code in _pidObjectsList)
            {
                _commands.Add(Factory.GetCommand(code.Code));
            }

            Execute();
        }

        public string Execute()
        {
            var response = string.Empty;
            foreach (var command in _commands)
            {
                command.Execute(_connection);
                response += $"{command}\n";
                //Console.ReadKey();
            }

            _connection.Close();

            return response;
        }
    }
}
