using Nand2TetrisVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nand2TetrisVM.Core.Managers
{
    public class AsmBuilder
    {
        private readonly ITranslatorManager _translatorManager;

        public AsmBuilder(ITranslatorManager translatorManager)
        {
            _translatorManager = translatorManager;
        }

        public string[] BuildAsmLines(List<ICommandLine> commandLines) 
        {
            List<string> asmLines = new List<string>();
            for (int i = 0; i < commandLines.Count; i++) 
            {
                var line = commandLines[i];
                if (string.IsNullOrEmpty(line.CommandString))
                    continue;

                var cmdLines = _translatorManager.TranslateToAsm(line);
                
                asmLines.AddRange(cmdLines);
            }

            return asmLines.ToArray();
        }

    }
}
