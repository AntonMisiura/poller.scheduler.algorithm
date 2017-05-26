using System.Collections.Generic;

namespace poller.scheduler.algorithm.Impl.Entities
{
    public class Car
    {
        public string Name { get; set; }

        public List<Pid> Pids { get; set; }
    }
}
