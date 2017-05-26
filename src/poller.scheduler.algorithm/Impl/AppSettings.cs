using RJCP.IO.Ports;
using System.Collections.Generic;

namespace poller.scheduler.algorithm.Impl
{
    public class AppSettings
    {
        public string Title { get; set; }

        /// <summary>
        /// Serial port parameters
        /// </summary>
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public string PortName { get; set; }
        public StopBits StopBits { get; set; }
    }
}
