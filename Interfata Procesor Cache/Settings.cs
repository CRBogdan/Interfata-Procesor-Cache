using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class Settings
    {
        public int fetchRate;
        public int instructionBufferSize;
        public int issueRateMaxim;
        public int dataCacheBlockSize;
        public int instructionCacheBlockSize;
        public int instructionCacheSize;

        public int hitLatency;
        public int missLatency;

        public string dataCacheType;

        public Settings validate() 
        {
            return this;
        }

        public Settings setFetchRate(int fetchRate)
        {
            this.fetchRate = fetchRate;
            return this;
        }

        public Settings setInstructionBufferSize(int instructionBufferSize)
        {
            this.instructionBufferSize = instructionBufferSize;
            return this;
        }

        public Settings setIssueRateMaxim(int issueRateMaxim)
        {
            this.issueRateMaxim = issueRateMaxim;
            return this;
        }

        public Settings setDataCacheBlockSize(int dataCacheBlockSize)
        {
            this.dataCacheBlockSize = dataCacheBlockSize;
            return this;
        }

        public Settings setInstructionCacheBlockSize(int instructionCacheBlockSize)
        {
            this.instructionCacheBlockSize = instructionCacheBlockSize;
            return this;
        }

        public Settings setInstructionCacheSize(int instructionCacheSize)
        {
            this.instructionCacheSize = instructionCacheSize;
            return this;
        }

        public Settings setHitLatency(int hitLatency)
        {
            this.hitLatency = hitLatency;
            return this;
        }

        public Settings setMissLatency(int missLatency)
        {
            this.missLatency = missLatency;
            return this;
        }

        public Settings setDataCacheType(string  dataCacheType)
        {
            this.dataCacheType = dataCacheType;
            return this;
        }
    }
}
