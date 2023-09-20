using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nand2TetrisAssembler.Core.Helpers;
using Nand2TetrisAssembler.Interfaces;

namespace TestConsole.Core.Translators
{
    // This class has responsibility of translating assembly code to binary code
    public class AssemblyTranslator : IAssemblyTranslator
    {
        public readonly Dictionary<string, string> compMappings = new Dictionary<string, string>
    {
        {"0", "0101010"},
        {"1", "0111111"},
        {"-1", "0111010"},
        {"D", "0001100"},
        {"A", "0110000"},
        {"!D", "0001101"},
        {"!A", "0110001"},
        {"-D", "0001111"},
        {"-A", "0110011"},
        {"D+1", "0011111"},
        {"A+1", "0110111"},
        {"D-1", "0001110"},
        {"A-1", "0110010"},
        {"D+A", "0000010"},
        {"D-A", "0010011"},
        {"A-D", "0000111"},
        {"D&A", "0000000"},
        {"D|A", "0010101"},
        {"M", "1110000"},
        {"!M", "1110001"},
        {"-M", "1110011"},
        {"M+1", "1110111"},
        {"M-1", "1110010"},
        {"D+M", "1000010"},
        {"D-M", "1010011"},
        {"M-D", "1000111"},
        {"D&M", "1000000"},
        {"D|M", "1010101"},
    };
        public readonly Dictionary<string, string> jumpMappings = new Dictionary<string, string>
    {
        {"JGT", "001"},
        {"JEQ", "010"},
        {"JGE", "011"},
        {"JLT", "100"},
        {"JNE", "101"},
        {"JLE", "110"},
        {"JMP", "111"},
    };
        private readonly IBinaryConverter _binaryConverter;
        private readonly IDestHelper _destHelper;

        public AssemblyTranslator(IBinaryConverter binaryConverter, IDestHelper destHelper)
        {
            _binaryConverter = binaryConverter;
            _destHelper = destHelper;
        }

        public string TranslateAInstruction(int address)
        {
            // Translate an A-instruction to binary code.
            return "0" + _binaryConverter.ToBinary(address).Substring(1); // Remove the leading '0'.
        }

        public string TranslateCInstruction(string instruction)
        {
            string binaryCode = "111"; // The leading 3 bits for all C-instructions.

            // Dest computation (7 bits).
            if (instruction.Contains('='))
            {
                string[] destComp = instruction.Split('=');
                string dest = destComp[0];
                string comp = destComp[1];
                string jump = "000"; // Default jump value.

                if (dest.Contains(';'))
                {
                    string[] destJump = dest.Split(';');
                    dest = destJump[0];
                    jump = destJump[1];
                }
                binaryCode += compMappings[comp] + _destHelper.Dest(dest) + (jumpMappings.ContainsKey(jump) ? jumpMappings[jump] : "000");// Check if jump exists in the dictionary.
            }
            // No dest computation (8 bits).
            else
            {
                string[] compJump = instruction.Split(';');
                string comp = compJump[0];
                string jump = compJump[1];

                binaryCode += compMappings[comp] + "000" + (jumpMappings.ContainsKey(jump) ? jumpMappings[jump] : "000"); // Check if jump exists in the dictionary.
            }

            return binaryCode;
        }
    }
}
