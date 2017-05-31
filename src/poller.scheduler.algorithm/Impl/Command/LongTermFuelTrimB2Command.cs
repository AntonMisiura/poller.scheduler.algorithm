using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class LongTermFuelTrimB2Command : CommandBase
    {
        public LongTermFuelTrimB2Command()
        {
            Name = "Long term fuel trim Bank 2";
            Pid = "01 09";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public double LongTermFuelTrimB2 { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {LongTermFuelTrimB2}";
        }

        protected override bool Parse(string data)
        {
            LongTermFuelTrimB2 = Convert.ToInt32(data.Split(' ')[2], 16) / 1.28 - 100;

            Console.WriteLine("Long term fuel trim Bank 2: " + LongTermFuelTrimB2);

            return true;
        }
    }
}
