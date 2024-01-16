using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfata_Procesor_Cache
{
    internal class InstructionProvider
    {
        private readonly StreamReader _stream;
        public readonly long length;

        public InstructionProvider(string traceFile)
        {
            _stream = new StreamReader(traceFile);
            length = _stream.BaseStream.Length;
        }

        public Instruction getNextInstruction()
        {
            if (_stream.EndOfStream)
                return null;

            int notChar = 0;
            string trace = "";

            while(notChar < 3)
            {
                if((char)_stream.Peek() != ' ' && (char)_stream.Peek() != '\n')
                {
                    trace += (char)_stream.Read();
                }
                else
                {
                    notChar++;
                    trace += " ";
                    while(_stream.Peek() == ' ' || (char)_stream.Peek() == '\n')
                    {
                        _stream.Read();
                    }
                }
            }
            trace = trace.Substring(0, trace.Length - 1);

            Instruction nextInstruction = new Instruction(trace);

            return nextInstruction;
        }
    }
}