using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nand2TetrisAssembler.Interfaces;

namespace Nand2TetrisAssembler.Core.Converters
{
    // Used to convert int values to binary
    public class BinaryConverter : IBinaryConverter
    {
        public string ToBinary(int value)
        {
            // Convert an integer value to a 16-bit binary string.
            return Convert.ToString(value, 2).PadLeft(16, '0');
        }
    }
}
