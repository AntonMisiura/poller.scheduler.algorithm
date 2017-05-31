using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class TimingAdvanceCommand : CommandBase
    {
        public TimingAdvanceCommand()
        {
            Name = "Timing Advance";
            Pid = "01 0E";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public double TimingAdvance { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {TimingAdvance}";
        }

        protected override bool Parse(string data)
        {
            TimingAdvance = Convert.ToInt32(data.Split(' ')[2], 16)/2.0 - 64;

            Console.WriteLine("Timing Advance: " + TimingAdvance);

            return true;
        }
    }
}
