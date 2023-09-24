using Nand2TetrisVM.Interfaces;
using Nand2TetrisVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nand2TetrisVM.Core.Factories
{
    public class CommandFactory : IFactory 
    {
        public CommandFactory() { }
        public ICommandLine CreateCommandLine<T>() where T : ICommandLine, new()
        {
            ICommandLine commandLine = new T();
            return commandLine;
        }
    }
}
