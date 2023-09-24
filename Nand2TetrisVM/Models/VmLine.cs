using Nand2TetrisVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Nand2TetrisVM.Models
{
    public sealed class VmLine : ICommandLine
    {
        public enum Mapping { SP, LCL, ARG, THIS, THAT }
        public enum CommandType { NONE, PUSH, POP, ADD, SUB, NEG, EQ, GT, LT, AND, OR, NOT  }
        public CommandType Command { get; set; }

        public string CommandString { get => Command.ToString().ToLower(); }
        public string Location { get; set; }
        public string Value { get; set; }

        public VmLine()
        {
            Command = CommandType.NONE;
            Location = string.Empty;
            Value = string.Empty;
        }
    }
}
