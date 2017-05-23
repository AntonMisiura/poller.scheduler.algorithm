using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using poller.scheduler.algorithm.Contract;
using RJCP.IO.Ports;


namespace poller.scheduler.algorithm.Impl
{
    public class OdbSerialPortConnection : IOdbConnection
    {
        private ILogger<OdbSerialPortConnection> _logger;
        private SerialPortStream Port;
        private AppSettings.AppSettings _config;

        public OdbSerialPortConnection(ILogger<OdbSerialPortConnection> logger,
            IOptions<AppSettings.AppSettings> config)
        {
            _config = config.Value;
            _logger = logger;
        }

        public bool Open()
        {
            try
            {
                if (Port == null)
                {
                    Port = new SerialPortStream();
                    Port = new SerialPortStream(_config.PortName.ToString(), _config.BaudRate, _config.DataBits, _config.Parity, _config.StopBits);
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
