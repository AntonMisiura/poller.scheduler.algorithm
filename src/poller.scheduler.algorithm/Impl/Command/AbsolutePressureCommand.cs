using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class AbsolutePressureCommand : CommandBase
    {
        public AbsolutePressureCommand()
        {
            Name = "Intake manifold absolute pressure";
            Pid = "01 0B";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public double AbsolutePressure { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {AbsolutePressure}";
        }

        protected override bool Parse(string data)
        {
            AbsolutePressure = Convert.ToInt32(data.Split(' ')[2], 16);
            
            Console.WriteLine("Absolute Pressure: " + AbsolutePressure);

            return true;
        }
    }
}
