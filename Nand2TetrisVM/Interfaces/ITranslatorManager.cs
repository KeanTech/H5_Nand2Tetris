using Nand2TetrisVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nand2TetrisVM.Interfaces
{
    public interface ITranslatorManager
    {

        List<string> TranslateToAsm(ICommandLine cmdLine);
        List<string> TranslateSub(ICommandLine cmdLine);
        List<string> TranslateAdd(ICommandLine cmdLine);
        List<string> TranslatePop(ICommandLine cmdLine);
        List<string> TranslatePush(ICommandLine cmdLine);
    }
}
