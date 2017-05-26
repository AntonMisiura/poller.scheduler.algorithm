using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl.Entities;
using RJCP.IO.Ports;

namespace poller.scheduler.algorithm.Impl.Connection
{
    public class ObdSerialPortConnection : IObdConnection
    {
        private ILogger<ObdSerialPortConnection> _logger;
        private SerialPortStream Port;
        private AppSettings _settings;

        public ObdSerialPortConnection(ILogger<ObdSerialPortConnection> logger,
            IOptions<AppSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public ObdSerialPortConnection()
        {
        }

        public bool Open()
        {
            try
            {
                if (Port == null)
                {
                    Port = new SerialPortStream();
                    Port = new SerialPortStream(_settings.PortName, _settings.BaudRate, _settings.DataBits, _settings.Parity, _settings.StopBits);
                    Port.Open();
                    Console.WriteLine("Serial port is opened.");
                }

                return Port.IsOpen;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to open port: {ex.Message}");
                return false;
            }
        }

        public void Close()
        {
            try
            {
                if (Port != null)
                {
                    Port.Close();
                    Port = null;
                    Console.WriteLine("Serial port is closed.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to close port: {ex.Message}");
            }
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            Console.WriteLine("Reading data...");
            return Port?.Read(buffer, offset, count) ?? -1;
        }

        public void Write(string data)
        {
            Console.WriteLine("Writing data...");
            Port?.Write(data);
        }

        public void Dispose()
        {
            Close();
        }
    }
}
