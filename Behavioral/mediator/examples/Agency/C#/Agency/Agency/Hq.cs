using System;
using System.Collections.Generic;
using System.Linq;

namespace Agency
{
    class Hq
    {
        private List<Agent> _agents = new List<Agent>();

        public Hq()
        {
            _agents.AddRange(
                new List<Agent>()
                {
                    new Agent(this, "Joe"),
                    new Agent(this, "Smith"),
                    new Agent(this, "Roberto"),
                    new Agent(this, "Cherry"),
                    new Agent(this, "Razor"),
                    new Agent(this, "Blade"),
                    new Agent(this, "Gustav"),
                    new Agent(this, "Petya")
                }
                );
        }

        public void SendIntelToAllAgents(Agent sender, string intel)
        {
            foreach(var agent in _agents.Where(a=> a!= sender))
            {
                agent.RecieveIntel(intel);
            }
        }

        public void CheckAgents()
        {
            foreach (var agent in _agents)
            {
                agent.SyncIntel();
            }
        }

        public string GetTotalIntel()
        {
            return _agents.Select(a => a.GetTotalIntel()).Aggregate((f, s) => $"{f}\n{s}");
        }
    }
}
