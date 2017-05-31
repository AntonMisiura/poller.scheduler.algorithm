using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class CalculatedEngineLoadCommand : CommandBase
    {
        public CalculatedEngineLoadCommand()
        {
            Name = "Calculated Engine Load";
            Pid = "01 04";
            BytesNum = 1;
            RequestsNum = 1;
        }

        public double CalculatedEngineLoad { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {CalculatedEngineLoad}";
        }

        protected override bool Parse(string data)
        {
            CalculatedEngineLoad = Convert.ToInt32(data.Split(' ')[2], 16)/2.55;
            
            Console.WriteLine("Calculated Engine Load: " + CalculatedEngineLoad);

            return true;
        }
    }
}
