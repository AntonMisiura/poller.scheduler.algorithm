using System;
using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl.Command;
using poller.scheduler.algorithm.Impl.Connection;

namespace poller.scheduler.algorithm.Impl.Service
{
    public class ObdManager
    {
        private IObdCommand[] _commands;
        private IObdConnection _connection;

        public ObdManager()
        {
            _connection = new ObdSerialPortConnection();
            _commands = new IObdCommand[]
            {
                new SupportedPidsCommand(), 
                new EngineRpmCommand(),
                new EngineTemperatureCommand(),
                new RoadSpeedCommand(),
                new ThrottlePositionCommand()
            };
        }

        public string Execute()
        {
            _connection.Open();

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
