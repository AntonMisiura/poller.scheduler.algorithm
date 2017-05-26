using System.Collections.Generic;
using System.Linq;
using poller.scheduler.algorithm.Impl.Entities;

namespace poller.scheduler.algorithm.Impl.Algorithm
{
    public class QuerySupportedPids
    {
        // final list of all supported pidsFromConfig
        private readonly Translator _translator;

        public List<PidObj> SupportedPids { get; private set; }

        public QuerySupportedPids(List<PidObj> pidsFromConfig, string obdResponse)
        {
            _translator = new Translator();
            SupportedPids = new List<PidObj>();

            CheckPids(pidsFromConfig, obdResponse);
            var prioritySum = SupportedPids.Sum(n => n.Priority);

            foreach (var item in SupportedPids)
            {
                item.Percent = item.Priority / (double)prioritySum;
            }
        }
        
        public void CheckPids(List<PidObj> pidsfromconfig, string obdResponse)
        {
            SupportedPids =  _translator.GetAvailablePids("88198000")
                .Join(pidsfromconfig, n => n, p => p.Code, (n, p) =>
                new PidObj(p.Name, p.Code, p.Priority)).ToList();
        }
    }
}