using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class FetchProvider
    {
        private int fetchRate;
        private InstructionProvider instructionProvider;
        private int programCounter;
        public bool isDone;
        public bool wasLastInstructionProcessed;
        public int PCBranch;
        private Instruction currentInstruction;

        public FetchProvider(int fetchRate, InstructionProvider instructionProvider)
        {
            this.fetchRate = fetchRate;
            this.instructionProvider = instructionProvider;
            this.isDone = false;
            this.programCounter = 0;
            this.PCBranch = -1;
            this.currentInstruction = instructionProvider.getNextInstruction();
            wasLastInstructionProcessed = false;
        }

        public List<Instruction> fetchInstructions()
        {
            List<Instruction> result = new List<Instruction>();

            for(int i = 0;  i < fetchRate; i++)
            {
                result.Add(new Instruction() { currentAddress = programCounter});

                if (wasLastInstructionProcessed)
                {
                    currentInstruction = instructionProvider.getNextInstruction();
                    wasLastInstructionProcessed = false;

                    if (currentInstruction == null)
                    {
                        isDone = true;
                        break;
                    }
                }

                if (result[i].currentAddress != currentInstruction.currentAddress)
                {
                    if(PCBranch == -1)
                    {
                        result[i].instrictionCode = "A";
                    }
                    else
                    {
                        result[i].instrictionCode = "X";
                    }
                }
                else
                {
                    if(currentInstruction.instrictionCode == "B")
                    {
                        PCBranch = currentInstruction.address;
                    }

                    result[i] = currentInstruction;
                    wasLastInstructionProcessed= true;
                }

                programCounter++;
            }

            if(PCBranch != -1)
            {
                programCounter = PCBranch;
                wasLastInstructionProcessed = false;
                PCBranch = -1;
            }

            if (result[3].instrictionCode == "B")
                wasLastInstructionProcessed = true;

            return result;
        }
    }
}
