using System;
using System.Collections.Generic;

namespace poller.scheduler.algorithm.Impl.Algorithm
{
    public class Translator
    {
        private List<string> _possiblePids;

        public List<string> availablePids { get; }

        public List<string> AvailablePids => availablePids;

        public Translator()
        {
            _possiblePids = CreatePidsList();
            availablePids = new List<string>();
        }

        public List<string> CreatePidsList()
        {
            var pids = new List<string>();
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F' };
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    if (i == 8 && j > 7)
                        break;

                    pids.Add(i.ToString() + j.ToString());
                }

                foreach (var letter in letters)
                {
                    if (i == 8)
                        break;

                    pids.Add(i.ToString() + letter.ToString());
                }
                pids.Remove("00");
            }

            return pids;
        }

        public List<string> GetAvailablePids(string input)
        {
            
            for (var i = 0; i < input.Length; i++)
            {
                var buf = (Convert.ToString(Convert.ToInt32(input[i].ToString(), 16), 2));
                var buf1 = Convert.ToInt32(buf);

                var res = "";

                res = buf1 >= 1000 ? buf1.ToString() : buf1.ToString("X4");

                var bufpid = new List<string>();

                var index = i * 4 + 4;

                if (index < _possiblePids.Count)
                {
                    bufpid = _possiblePids.GetRange(i * 4, 4);
                    for (var j = 0; j < bufpid.Count; j++)
                    {
                        if (res[j] == '1') availablePids.Add(bufpid[j]);
                    }
                }
                else
                {
                    bufpid = _possiblePids.GetRange(i*4, _possiblePids.Count-i*4);
                    for (var j = 0; j < bufpid.Count; j++)
                    {
                        if (res[j] == '1') availablePids.Add(bufpid[j]);
                    }
                    break;
                }
            }
            return availablePids;
        }
    }
}
