namespace Nand2TetrisAssembler.Core.Extentions
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
    }
}
