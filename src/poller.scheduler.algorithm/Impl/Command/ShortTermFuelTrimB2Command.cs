using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class ShortTermFuelTrimB2Command : CommandBase
    {
        public ShortTermFuelTrimB2Command()
        {
            Name = "Short term fuel trim Bank 2";
            Pid = "01 08";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public double ShortTermFuelTrimB2 { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {ShortTermFuelTrimB2}";
        }

        protected override bool Parse(string data)
        {
            ShortTermFuelTrimB2 = Convert.ToInt32(data.Split(' ')[2], 16) / 1.28 - 100;

            Console.WriteLine("Short term fuel trim Bank 2: " + ShortTermFuelTrimB2);

            return true;
        }
    }
}
