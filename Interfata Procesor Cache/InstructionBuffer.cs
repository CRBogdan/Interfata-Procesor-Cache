using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class InstructionBuffer
    {
        private readonly Settings _settings;

        private Queue<Instruction> instructions;
        public bool canAdd;

        public InstructionBuffer(Settings settings)
        {
            this._settings = settings;

            instructions = new Queue<Instruction>();
            canAdd = true;
        }

        public void addInstructions(List<Instruction> instructions)
        {
            if (!canAdd)
                return;

            foreach (Instruction instruction in instructions)
            {
                this.instructions.Enqueue(instruction);
            }

            if(instructions.Count + _settings.fetchRate > _settings.instructionBufferSize)
                canAdd = false;
            else
                canAdd = true;
        }

        public List<Instruction> getInstruction()
        {
            var result = new List<Instruction>();

            for(int i = 0; i < _settings.issueRateMaxim; i++)
            {
                result.Add(instructions.Dequeue());
            }

            if (instructions.Count + _settings.fetchRate > _settings.instructionBufferSize)
                canAdd = false;
            else
                canAdd = true;

            return result;
        }
    }
}
