using Nand2TetrisAssembler.Core.Extentions;
using Nand2TetrisAssembler.Interfaces;

namespace Nand2TetrisAssembler.Core.Assemblers
{
    // This is use to convert the assembly code to the Hack binary
    public class HackAssembler : IAssembler
    {
        private readonly Dictionary<string, int> symbolTable = new Dictionary<string, int>()
        {
            { "SP", 0 },
            { "LCL", 1},
            { "ARG", 2}
        };
        private readonly IAssemblyTranslator _assemblyTranslator;

        public HackAssembler(IAssemblyTranslator assemblyTranslator)
        {
            _assemblyTranslator = assemblyTranslator;
        }

        public void Assemble(string inputFileName, string outputFileName)
        {
            List<string> binaryCode = new List<string>();

            using (StreamReader reader = new StreamReader(inputFileName))
            {
                int instructionAddress = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();
                    line = line.RemoveCommentsAndWhitespace();

                    if (line.Length == 0)
                        continue; // Skip empty lines

                    if (line.StartsWith("(") && line.EndsWith(")"))
                    {
                        // Label declaration
                        string label = line.Substring(1, line.Length - 2);
                        symbolTable[label] = instructionAddress;
                    }
                    else
                    {
                        // A-instruction or C-instruction
                        instructionAddress++;
                    }
                }

                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                int variableAddress = 16;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();
                    line = line.RemoveCommentsAndWhitespace();

                    if (line.Length == 0 || line.StartsWith("("))
                        continue;

                    if (line.StartsWith("@"))
                    {
                        // A-instruction
                        string symbol = line.Substring(1);
                        int address;

                        if (int.TryParse(symbol, out address))
                        {
                            binaryCode.Add(_assemblyTranslator.TranslateAInstruction(address));
                        }
                        else
                        {
                            if (!symbolTable.ContainsKey(symbol))
                            {
                                symbolTable[symbol] = variableAddress++;
                            }

                            binaryCode.Add(_assemblyTranslator.TranslateAInstruction(symbolTable[symbol]));
                        }
                    }
                    else
                    {
                        // C-instruction
                        binaryCode.Add(_assemblyTranslator.TranslateCInstruction(line));
                    }
                }
            }

            File.WriteAllLines(outputFileName, binaryCode);
            Console.WriteLine("Assembly code successfully converted to binary.");
        }
    }
}
