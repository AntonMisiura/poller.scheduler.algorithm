using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class SupportedPidsCommand : CommandBase
    {
        public SupportedPidsCommand()
        {
            Name = "Supported PID's";
            Pid = "01 00";
            BytesNum = 4;
            RequestsNum = 1;
        }

        public int SupportedPids { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {SupportedPids}";
        }

        protected override bool Parse(string data)
        {
            SupportedPids = Convert.ToInt32(data.Split(' ')[2]);
            return true;
        }
    }
}
