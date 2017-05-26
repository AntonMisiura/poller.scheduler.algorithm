using System;
using System.Collections.Generic;
using System.Linq;
using poller.scheduler.algorithm.Impl.Entities;

namespace poller.scheduler.algorithm.Impl.Algorithm
{
    public class Poller
    {
        private const int WorkingSetSize = 1000;

        private List<PidObj> _queue;

        public Poller(List<PidObj> pids, string obdResponse)
        {
            _queue = new List<PidObj>();
            var querySupportedPids = new QuerySupportedPids(pids, obdResponse);

            foreach (var item in querySupportedPids.SupportedPids)
            {
                QueryFormer(item);
            }
        }

        public void QueryFormer(PidObj p)
        {
            var amount = (int)Math.Round(WorkingSetSize * p.Percent);

            for (var i = 0; i < amount; i++)
            {
                _queue.Add(p);
            }

            _queue = _queue.Take(1000).ToList();
            _queue.Shuffle();
        }
    }
}