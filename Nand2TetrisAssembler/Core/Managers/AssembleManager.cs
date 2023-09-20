using Nand2TetrisAssembler.Interfaces;

namespace Nand2TetrisAssembler.Core.Managers
{
    public class AssembleManager
    { 
        private readonly IAssembler _assembler;

        public AssembleManager(IAssembler assembler)
        {
            _assembler = assembler;
        }

        public void Assemble(string inputFilePath, string outputFilePath) 
        {
            _assembler.Assemble(inputFilePath, outputFilePath);
        }

    }
}
