namespace poller.scheduler.algorithm.Impl.Entities
{
    public class PidObj : Pid
    {
        public double Percent { get; set; }

        public PidObj(string name, string code, int priority) {
            this.Name = name;
            this.Code = code;
            this.Priority = priority;
        }
    }
}