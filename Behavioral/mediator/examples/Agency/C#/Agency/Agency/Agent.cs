using System;
using System.Collections.Generic;
using System.Linq;

namespace Agency
{
    class Agent
    {
        private List<string> _intel = new List<string>();
        private Hq _hq;
        private readonly string _name;

        private string GetGeneratedIntel()
        {
            return $"Secret intel: {Guid.NewGuid().GetHashCode()}";
        }

        public void RecieveIntel(string intel)
        {
            _intel.Add(intel);
        }

        public void SyncIntel()
        {
            var intel = GetGeneratedIntel();
            _intel.Add(intel);

            _hq.SendIntelToAllAgents(this, intel);
        }

        public string GetTotalIntel()
        {
            return $"{_name}\n{_intel.Aggregate((f,s)=> $"{f}\n{s}")}";
        }

        public Agent(Hq hq, string name)
        {
            _name = name;
            _hq = hq;
        }
    }
}
