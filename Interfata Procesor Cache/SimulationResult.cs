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
        public int issueRate;
        public int instructionCacheMiss;
        public int instructionCacheMissRate;
        public int dataCacheMiss;
        public int dataCacheMissRate;
        public int dataCacheAccesses;
    }
}
