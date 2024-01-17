using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class SimulationResult
    {
        public int oneCycleInstructions;
        public int loadInstructions;
        public int storeInstructions;
        public int branchInstructions;
        public int totalInstructions;
        public int ticks;
        public double issueRate;
        public int instructionCacheMiss;
        public double instructionCacheMissRate;
        public int dataCacheMiss;
        public double dataCacheMissRate;
        public int dataCacheAccesses;
    }
}
