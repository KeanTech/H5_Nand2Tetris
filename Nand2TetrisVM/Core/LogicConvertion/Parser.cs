using Nand2TetrisVM.Core.Extentions;
using Nand2TetrisVM.Interfaces;
using Nand2TetrisVM.Models;
using System.Data.Common;

namespace Nand2TetrisVM.Core.LogicConvertion
{
    public class Parser<T> : ICommandParser where T : ICommandLine, new()
    {
        private readonly IFactory _factory;
        public Parser(IFactory factory)
        {
            _factory = factory;
        }

        public ICommandLine ParseLine(string line)
        {

            ICommandLine commandLine = _factory.CreateCommandLine<T>();
            string[] commands = line.Split(' ');

            if (commands.Length <= 2)
            {
                commandLine.Command = commands[0].GetCommand();
                return commandLine;
            }

            commandLine.Command = commands[0].GetCommand();
            commandLine.Location = commands[1];
            commandLine.Value = commands[2];

            return commandLine;
        }

        public List<ICommandLine> ParseLines(string[] lines)
        {
            List<ICommandLine> vm = new List<ICommandLine>();

            foreach (string line in lines)
            {
                try
                {
                    ICommandLine vmLine = ParseLine(line.RemoveCommentsAndWhitespace());

                    if (vmLine.CommandString == VmLine.CommandType.NONE.ToString().ToLower())
                        continue;

                    vm.Add(vmLine);
                }
                catch (Exception ex)
                {
                    throw new InvalidDataException(ex.Message, ex.InnerException);
                }

            }

            return vm;
        }
    }
}
