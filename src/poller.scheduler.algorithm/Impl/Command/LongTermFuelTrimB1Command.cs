using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class LongTermFuelTrimB1Command : CommandBase
    {
        public LongTermFuelTrimB1Command()
        {
            Name = "Long term fuel trim Bank 1";
            Pid = "01 07";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public double LongTermFuelTrimB1 { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {LongTermFuelTrimB1}";
        }

        protected override bool Parse(string data)
        {
            LongTermFuelTrimB1 = Convert.ToInt32(data.Split(' ')[2], 16) / 1.28 - 100;

            Console.WriteLine("Long term fuel trim Bank 1: " + LongTermFuelTrimB1);

            return true;
        }
    }
}
