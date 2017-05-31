using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class ShortTermFuelTrimB1Command : CommandBase
    {
        public ShortTermFuelTrimB1Command()
        {
            Name = "Short term fuel trim Bank 1";
            Pid = "01 06";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public double ShortTermFuelTrimB1 { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {ShortTermFuelTrimB1}";
        }

        protected override bool Parse(string data)
        {
            ShortTermFuelTrimB1 = Convert.ToInt32(data.Split(' ')[2], 16) / 1.28 - 100;

            Console.WriteLine("Short term fuel trim Bank 1: " + ShortTermFuelTrimB1);

            return true;
        }
    }
}
