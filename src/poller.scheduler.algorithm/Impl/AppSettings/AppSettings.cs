using RJCP.IO.Ports;

namespace poller.scheduler.algorithm.Impl.AppSettings
{
    public class AppSettings
    {
        public string Title { get; set; }
        
        /// <summary>
        /// Serial ports parameters
        /// </summary>
        public string PortName { get; set; }

        public int BaudRate { get; set; }
        
        public Parity Parity { get; set; }

        public int DataBits { get; set; }
        
        public StopBits StopBits { get; set; }
    }
}
