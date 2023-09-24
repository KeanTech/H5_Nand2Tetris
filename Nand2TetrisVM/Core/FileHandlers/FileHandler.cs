namespace Nand2TetrisVM.Core.FileHandlers
{
    public class FileHandler
    {
        public List<string> ReadFile(string path)
        {
            List<string> result = new List<string>();

            if (File.Exists(path))
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            while (sr.EndOfStream == false)
                            {
                                result.Add(sr.ReadLine());
                            }
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("There was an error while writing to file:\n" + ex.Message);
                }

            }

            throw new FileNotFoundException("At this path: {0}", path);
        }

        public void WriteFile(string path, string[] value)
        {

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (string s in value) 
                            sw.WriteLine(s);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error while writing to file:\n" + ex.Message);
            }



        }

    }
}
