using System;

namespace poller.scheduler.algorithm.Impl.Command
{
    public class MassAirflowCommand : CommandBase
    {
        public MassAirflowCommand()
        {
            Name = "MAF airflow rate";
            Pid = "01 10";
            BytesNum = 2;
            RequestsNum = 1;
        }

        public double MassAirflow { get; private set; }

        public override string ToString()
        {
            return $"{Name}: {MassAirflow}";
        }

        protected override bool Parse(string data)
        {
            var dataA = Convert.ToInt32(data.Split(' ')[2], 16) * 256;
            var dataB = Convert.ToInt32(data.Split(' ')[3], 16);

            MassAirflow = (dataA + dataB) / 100.0;
            Console.WriteLine("MAF airflow rate: " + MassAirflow);

            return true;
        }
    }
}
