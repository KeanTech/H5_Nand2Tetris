using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nand2TetrisAssembler.Interfaces;

namespace Nand2TetrisAssembler.Core.Helpers
{
    // This class helps determine what a dest is translated into
    public class DestHelper : IDestHelper
    {
        // Helper method for translating dest (3 bits).
        public string Dest(string dest)
        {
            string a = (dest.Contains('A')) ? "1" : "0";
            string d = (dest.Contains('D')) ? "1" : "0";
            string m = (dest.Contains('M')) ? "1" : "0";

            return a + d + m;
        }
    }
}
