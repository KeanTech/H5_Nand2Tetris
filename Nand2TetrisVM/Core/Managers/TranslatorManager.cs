using Nand2TetrisVM.Core.Extentions;
using Nand2TetrisVM.Interfaces;
using Nand2TetrisVM.Models;
using System;
using System.Reflection;

namespace Nand2TetrisVM.Core.Managers
{
    public class TranslatorManager : ITranslatorManager
    {

        public List<string> TranslateToAsm(ICommandLine cmdLine)
        {
            VmLine.CommandType cmd = cmdLine.CommandString.GetCommand();

            switch (cmd)
            {
                case VmLine.CommandType.PUSH:
                    return TranslatePush(cmdLine);

                case VmLine.CommandType.POP:
                    return TranslatePop(cmdLine);

                case VmLine.CommandType.ADD:
                    return TranslateAdd(cmdLine);

                case VmLine.CommandType.SUB:
                    return TranslateSub(cmdLine);

                default:
                    throw new ArgumentNullException("The given command is not valid");
            }
        }
        public List<string> TranslateSub(ICommandLine cmdLine)
        {
            List<string> asmLines = new List<string>();
            if (cmdLine.CommandString != VmLine.CommandType.ADD.ToString().ToLower())
                return asmLines;

            asmLines.Add("@0");
            asmLines.Add("A=M-1");
            asmLines.Add("D=M");
            asmLines.Add("A=A-1");
            asmLines.Add("M=M-D");
            asmLines.Add("M=M-1");

            return asmLines;
        }
        public List<string> TranslateAdd(ICommandLine cmdLine)
        {
            List<string> asmLines = new List<string>();
            if (cmdLine.CommandString != VmLine.CommandType.ADD.ToString().ToLower())
                return asmLines;

            asmLines.Add("@0");
            asmLines.Add("A=M-1");
            asmLines.Add("D=M");
            asmLines.Add("A=A-1");
            asmLines.Add("M=D+M");
            //asmLines.Add("M=M-1");

            return asmLines;
        }
        public List<string> TranslatePop(ICommandLine cmdLine)
        {
            List<string> asmLines = new List<string>();
            if (cmdLine.CommandString != VmLine.CommandType.POP.ToString().ToLower())
                return asmLines;

            GeneratePopLocationLines(asmLines, cmdLine.Location, cmdLine.Value);
            return asmLines;
        }

        private List<string> GeneratePopLocationLines(List<string> lines, string location, string index)
        {
            lines.AddRange(location.PopRamSpots());
            return lines;
        }
        private List<string> GeneratePushLocationLines(List<string> lines, string location, string index)
        {
            lines.AddRange(location.PushRamSpots());
            return lines;
        }

        public List<string> TranslatePush(ICommandLine cmdLine)
        {
            List<string> asmLines = new List<string>();
            if (cmdLine.CommandString != VmLine.CommandType.PUSH.ToString().ToLower())
                return asmLines;

            GeneratePushLocationLines(asmLines, cmdLine.Location, cmdLine.Value);

            return asmLines;
        }
    }
}