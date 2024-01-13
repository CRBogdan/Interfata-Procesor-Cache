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
    }
}
