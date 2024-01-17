using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class DataCache
    {
        private readonly Settings _settings;
        private int cacheSize;
        private int blockSize;
        private Cache[] cache;

        public int dataHits;
        public int dataMisses;
        public DataCache(Settings settings)
        {
            _settings = settings;
            cache = new Cache[settings.dataCacheSize];
            cacheSize = settings.instructionCacheSize;
            blockSize = settings.fetchRate;
        }

        public int check(Instruction instruction)
        {
            int tag = instruction.address / cacheSize;
            int idx = (instruction.address % cacheSize) / blockSize;

            if (cache[idx] != null && cache[idx].tag == tag)
            {
                dataHits++;
                return _settings.hitLatency;
            }
            else
            {
                dataMisses++;
                cache[idx] = new Cache { tag = tag };
                return _settings.missLatency;
            }
        }
    }
}
