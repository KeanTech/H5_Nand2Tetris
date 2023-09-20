namespace Nand2TetrisAssembler.Interfaces
{
    public interface IAssemblyTranslator
    {
        string TranslateAInstruction(int address);
        string TranslateCInstruction(string instruction);
    }
}
