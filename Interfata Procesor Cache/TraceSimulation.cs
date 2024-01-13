using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class TraceSimulation
    {
        readonly string _name;
        readonly List<string> _traces;
        Regex splitRegex = new Regex(@"[BLS]\s*\d*\s*\d*");

        public TraceSimulation(string name)
        {
            _name = name;

            using (var reader = new StreamReader($"./Traces/{_name}.trc"))
            {
                string unformattedData = reader.ReadToEnd();
                _traces = [.. splitRegex.Matches(unformattedData).Select(x=>x.Value)];
            }
        }

        public async void startSimulation(Action<string, int> simulationUpdateCallback)
        {
            for(int i = 0; i < _traces.Count; i++)
            {
                simulationUpdateCallback(_name, i);
            }
        }
    }
}
