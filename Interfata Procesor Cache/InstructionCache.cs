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
        public InstructionCache(Settings settings) 
        {
            this._settings = settings;
        }

        public int check(Instruction instruction)
        {
            return _settings.hitLatency;
        }
    }
}
