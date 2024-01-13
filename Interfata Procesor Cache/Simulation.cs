using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class Simulation
    {
        readonly Settings _settings;
        readonly string[] _files;

        public Action<string, int> simulatuinUpdateCallback;
        List<TraceSimulation> traceSimulations = new List<TraceSimulation>();

        public Simulation(Settings settings, string[] files, Action<string, int> simulatuinUpdateCallback)
        {
            _settings = settings;
            _files = files;

            foreach (var file in _files)
            {
                traceSimulations.Add(new TraceSimulation(file));
            }

            this.simulatuinUpdateCallback = simulatuinUpdateCallback;
        }

        public void startSimulation()
        {
            foreach (var sim in traceSimulations)
            {
                sim.startSimulation(simulatuinUpdateCallback);
            }
        }
    }
}
