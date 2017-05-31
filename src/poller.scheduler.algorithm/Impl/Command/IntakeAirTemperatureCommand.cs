using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class IntakeAirTemperatureCommand : CommandBase
    {
        public IntakeAirTemperatureCommand()
        {
            Name = "Intake air temperature";
            Pid = "01 0F";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public double IntakeAirTemperature { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {IntakeAirTemperature}";
        }

        protected override bool Parse(string data)
        {
            IntakeAirTemperature = Convert.ToInt32(data.Split(' ')[2], 16) - 40;

            Console.WriteLine("Intake Air Temperature: " + IntakeAirTemperature);

            return true;
        }
    }
}
