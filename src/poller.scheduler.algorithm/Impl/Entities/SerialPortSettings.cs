using RJCP.IO.Ports;

namespace poller.scheduler.algorithm.Impl.Entities
{
    public class SerialPortSettings
    {
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
