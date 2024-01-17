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
        private readonly Settings _settings;

        private FetchProvider fetchProvider;
        private string name;
        private InstructionBuffer instructionBuffer;
        private InstructionCache instructionCache;
        private DataCache dataCache;

        private int mainClock;

        private int oneCycleInstructions = 0;
        private int loadInstructions = 0;
        private int storeInstructions = 0;
        private int branchInstructions = 0;

        public TraceSimulation(string name, Settings settings)
        {
            _settings = settings;
            this.name = name;

            var instructionProvider = new InstructionProvider($"./Traces/{name}.trc");
            fetchProvider = new FetchProvider(settings.fetchRate, instructionProvider);
            instructionBuffer = new InstructionBuffer(settings);
            instructionCache = new InstructionCache(settings);
            dataCache = new DataCache(settings);

            mainClock = 0;
        }

        public Task<TraceSimulation> startSimulationAsync(Action<string, int> simulationUpdateCallback)
        {
            return Task.Run(()=>
            {
                startSimulation(simulationUpdateCallback);
                return this;
            });
        }

        private void startSimulation(Action<string, int> simulationUpdateCallback)
        {
            do
            {
                do
                {
                    instructionBuffer.addInstructions(fetchProvider.fetchInstructions());

                    executeInstructions(instructionBuffer.getInstruction());
                } while (!instructionBuffer.canAdd);
            } while (!fetchProvider.isDone);

            while (!instructionBuffer.isEmpty)
            {
                executeInstructions(instructionBuffer.getInstruction());
            }
        }

        private void executeInstructions(List<Instruction> instructions)
        {
            mainClock = mainClock + instructionCache.check(instructions[0]);

            foreach(Instruction instruction in instructions)
            {

                if (instruction.instrictionCode == "A")
                    oneCycleInstructions++;

                if(instruction.instrictionCode == "B")
                    branchInstructions++;

                if(instruction.instrictionCode == "L")
                    loadInstructions++;

                if (instruction.instrictionCode == "S")
                    storeInstructions++;

                if (instruction.instrictionCode == "L" || instruction.instrictionCode == "S")
                    mainClock = mainClock + dataCache.check(instruction);
            }
            mainClock = mainClock + this._settings.hitLatency;
        }

        public SimulationResult GetSimulationResult()
        {
            return new SimulationResult
            {
                oneCycleInstructions = this.oneCycleInstructions,
                loadInstructions = this.loadInstructions,
                storeInstructions = this.storeInstructions,
                branchInstructions = this.branchInstructions,
                totalInstructions = this.oneCycleInstructions + this.loadInstructions + this.storeInstructions + this.branchInstructions,
                ticks = this.mainClock,
                issueRate = (double)(this.oneCycleInstructions + this.loadInstructions + this.storeInstructions + this.branchInstructions)/(double)mainClock,
                instructionCacheMiss = instructionCache.instructionMisses,
                instructionCacheMissRate = (double)instructionCache.instructionMisses / (double)(instructionCache.instructionMisses + instructionCache.instructionHits),
                dataCacheMiss = dataCache.dataMisses,
                dataCacheMissRate = (double)dataCache.dataMisses / (double)(dataCache.dataMisses + dataCache.dataHits),
                dataCacheAccesses = dataCache.dataMisses + dataCache.dataHits
            };
        }
    }
}