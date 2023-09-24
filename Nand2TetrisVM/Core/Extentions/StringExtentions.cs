using Nand2TetrisVM.Models;
using System.ComponentModel.DataAnnotations;

namespace Nand2TetrisVM.Core.Extentions
{
    // This class holds extentions for strings
    public static class StringExtentions
    {
        public static string RemoveCommentsAndWhitespace(this string input)
        {
            // Remove comments and whitespace from a line.
            int commentIndex = input.IndexOf("//");
            if (commentIndex != -1)
            {
                input = input.Substring(0, commentIndex).Trim();
            }
            else
            {
                input = input.Trim();
            }

            return input;
        }

        public static VmLine.CommandType GetCommand(this string command)
        {
            switch (command.ToLower())
            {
                case "push":
                    return VmLine.CommandType.PUSH;

                case "pop":
                    return VmLine.CommandType.POP;

                case "add":
                    return VmLine.CommandType.ADD;

                case "sub":
                    return VmLine.CommandType.SUB;

                case "neg":
                    return VmLine.CommandType.NEG;

                case "eq":
                    return VmLine.CommandType.EQ;

                case "gt":
                    return VmLine.CommandType.GT;

                case "lt":
                    return VmLine.CommandType.LT;

                case "and":
                    return VmLine.CommandType.AND;

                case "or":
                    return VmLine.CommandType.OR;

                case "not":
                    return VmLine.CommandType.NOT;

                default:
                    return VmLine.CommandType.NONE;
            }
        }

        public static string[] PushRamSpots(this string input)
        {
            return new string[] { $"@{input.GetPointerPosition()}", "A=M", "M=D", $"@{input.GetPointerPosition()}", "M=M+1" };
        }

        public static string[] PopRamSpots(this string input)
        {
            return new string[] { $"@{input.GetPointerPosition()}", "A=M", "D=M", $"@{input.GetPointerPosition()}", "M=M-1" };
        }

        public static string GetPointerPosition(this string location)
        {
            switch (location.ToLower())
            {
                case "constant":
                    return ((int)VmLine.Mapping.SP).ToString();

                case "local":
                    return ((int)VmLine.Mapping.LCL).ToString();

                case "argument":
                    return ((int)VmLine.Mapping.ARG).ToString();

                case "pointer0":
                    return ((int)VmLine.Mapping.THIS).ToString();

                case "pointer1":
                    return ((int)VmLine.Mapping.THAT).ToString();

                case "temp":
                    return "5";

                default:
                    return ((int)VmLine.Mapping.SP).ToString();
            }
        }
    }
}
