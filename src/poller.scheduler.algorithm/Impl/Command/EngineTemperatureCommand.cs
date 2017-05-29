using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class EngineTemperatureCommand : CommandBase
    {
        public EngineTemperatureCommand()
        {
            Name = "Engine Temperature";
            Pid = "01 05";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public int EngineTemperature { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {EngineTemperature}";
        }

        protected override bool Parse(string data)
        {
            EngineTemperature = Convert.ToInt32(data.Split(' ')[2], 16) - 40;
            Console.WriteLine(EngineTemperature);
            return true;
        }
    }
}
