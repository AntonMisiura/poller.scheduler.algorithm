using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class FuelPressureCommand : CommandBase
    {
        public FuelPressureCommand()
        {
            Name = "Fuel Pressure(gauge pressure)";
            Pid = "01 0A";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public double FuelPressure { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {FuelPressure}";
        }

        protected override bool Parse(string data)
        {
            FuelPressure = Convert.ToInt32(data.Split(' ')[2], 16) * 3;

            Console.WriteLine("Fuel Pressure: " + FuelPressure);

            return true;
        }
    }
}
