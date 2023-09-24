using Nand2TetrisVM.Core.LogicConvertion;
using System.Windows.Input;

namespace Nand2TetrisVM.Interfaces
{
    public interface ICommandParser
    {
        ICommandLine ParseLine(string line);
        List<ICommandLine> ParseLines(string[] lines);
    }
}