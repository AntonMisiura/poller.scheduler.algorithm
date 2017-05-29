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

        public string SupportedPids { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {SupportedPids}";
        }

        protected override bool Parse(string data)
        {
            SupportedPids = data.Remove(0, 6);
            SupportedPids = SupportedPids.Replace(" ", string.Empty);
            Console.WriteLine(SupportedPids);
            return true;
        }
    }
}
