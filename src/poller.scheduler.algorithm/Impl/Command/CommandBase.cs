﻿using System;
using System.Text;
using Microsoft.Extensions.Logging;
using poller.scheduler.algorithm.Contract;

namespace poller.scheduler.algorithm.Impl.Command
{
    public abstract class CommandBase : IObdCommand
    {
        public string Name { get; protected set; }
        public string Pid { get; protected set; }
        public int BytesNum { get; protected set; }
        public int RequestsNum { get; protected set; }

        private ILogger _logger;

        public CommandBase(ILogger logger)
        {
            _logger = logger;
        }

        protected CommandBase()
        {

        }

        public bool Execute(IObdConnection connection)
        {
            try
            {
                var data = GetData(connection);
                return Parse(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get and parse data: {ex.Message}");
                return false;
            }
        }

        protected abstract bool Parse(string data);

        protected string GetData(IObdConnection connection)
        {
            // Write PID request
            connection.Write($"{Pid} {RequestsNum}\r");

            // Read PID response
            var response = string.Empty;  // string to be returned
            while (!response.Contains(">"))
            {
                //loop until a ">" is recd. End of line char with the ELM327
                //or 200 msec timeout and no read, exit the loop and timer function too
                try
                {
                    var buffer = new byte[20]; // the pid data buffer
                    var count = connection.Read(buffer, 0, buffer.Length);
                    response += Encoding.ASCII.GetString(buffer, 0, count);
                }
                catch (TimeoutException ex)
                {
                    _logger.LogError($"Failed to read data: {ex.Message}");

                    response = string.Empty;
                    break;
                }
            }

            //Validate PID response
            //Get the data and put in array  and convert to a string and return string
            //Replace the pid request with 41 to match the OBD response
            var responsePos = response.IndexOf(Pid.Replace("01", "41"), StringComparison.Ordinal);
            if (responsePos > -1 && !response.Contains("DATA") && response.Length >= 7)
                response = response.Substring(responsePos, 5 + 3 * BytesNum);

            return response;
        }
    }
}
