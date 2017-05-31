using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class RunTimeSinceEngineStartCommand : CommandBase
    {
        public RunTimeSinceEngineStartCommand()
        {
            Name = "Run time since engine start";
            Pid = "01 1F";
            BytesNum = 2;
            RequestsNum = 1;
        }

        public double RunTimeEngine { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {RunTimeEngine}";
        }

        protected override bool Parse(string data)
        {
            var dataA = Convert.ToInt32(data.Split(' ')[2], 16) * 256;
            var dataB = Convert.ToInt32(data.Split(' ')[3], 16);

            RunTimeEngine = (dataA + dataB);
            Console.WriteLine("Run time since engine start: " + RunTimeEngine);

            return true;
        }
    }
}
