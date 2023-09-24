using Nand2TetrisVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nand2TetrisVM.Interfaces
{
    public interface ICommandLine
    {
        VmLine.CommandType Command { get; set; }
        public string CommandString { get; }
        public string Location { get; set; }
        public string Value { get; set; }
    }
}
