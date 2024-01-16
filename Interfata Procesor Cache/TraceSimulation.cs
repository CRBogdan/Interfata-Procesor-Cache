using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class TraceSimulation
    {
        private FetchProvider fetchProvider;
        private string name;
        private InstructionBuffer instructionBuffer;

        public TraceSimulation(string name, Settings settings)
        {
            this.name = name;

            var instructionProvider = new InstructionProvider($"./Traces/{name}.trc");
            fetchProvider = new FetchProvider(settings.fetchRate, instructionProvider);
            instructionBuffer = new InstructionBuffer(settings);
        }

        public Task startSimulationAsync(Action<string, int> simulationUpdateCallback)
        {
            return Task.Run(()=>startSimulation(simulationUpdateCallback));
        }

        private void startSimulation(Action<string, int> simulationUpdateCallback)
        {
            do
            {
                do
                {
                    instructionBuffer.addInstructions(fetchProvider.fetchInstructions());

                    executeInstructions(instructionBuffer.getInstruction());
                } while (instructionBuffer.canAdd);
            } while (!fetchProvider.isDone);
        }

        private void executeInstructions(List<Instruction> instructions)
        {

        }
    }
}