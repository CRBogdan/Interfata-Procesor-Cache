using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class Instruction
    {
        public string instrictionCode;
        public int currentAddress;
        public int address;

        private Regex instructionCodeRegex = new Regex(@"[BLS]");
        private Regex currentAddressRegex = new Regex(@"\d+");
        private Regex addressRegex = new Regex(@"\d+$");

        public Instruction()
        {
        }

        public Instruction(string trace) 
        {
            instrictionCode = instructionCodeRegex.Match(trace).ToString();
            currentAddress = int.Parse(currentAddressRegex.Match(trace).ToString());
            address = int.Parse(addressRegex.Match(trace).ToString());
        }
    }
}
