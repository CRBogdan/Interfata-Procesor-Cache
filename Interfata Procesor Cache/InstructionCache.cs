using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class InstructionCache
    {
        private readonly Settings _settings;
        private int cacheSize;
        private int blockSize;
        private Cache[] cache;

        public int instructionHits;
        public int instructionMisses;

        public InstructionCache(Settings settings) 
        {
            this._settings = settings;
            cache = new Cache[settings.instructionCacheSize];
            cacheSize = settings.instructionCacheSize;
            blockSize = settings.fetchRate;
        }

        public int check(Instruction instruction)
        {
            int tag = instruction.currentAddress / cacheSize;
            int idx = (instruction.currentAddress % cacheSize) / blockSize;

            if (cache[idx] != null && cache[idx].tag == tag)
            {
                instructionHits++;
                return _settings.hitLatency;
            }
            else
            {
                instructionMisses++;
                cache[idx] = new Cache { tag = tag};
                return _settings.missLatency;
            }
        }
    }
}
