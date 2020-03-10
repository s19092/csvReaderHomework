using System;
using System.IO;

namespace csvReaderXML
{
    class Program
    {

        static String DEFAULT_SOURCE_PATH = "data.csv";
        static String DEFAULT_TARGET_PATH = "result.xml";
        static String DEFAULT_FORMAT = "xml";
        static void Main(string[] args)
        {

            System.IO.StreamWriter logsFile = new System.IO.StreamWriter(@"Logs.txt");
            

            String csvPath;
            String targetPath;
            String format;

            if (args.Length == 3)
            {
                
                
                csvPath = args[0];
                try {
                    PathTest(csvPath);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    csvPath = DEFAULT_SOURCE_PATH;
                    logsFile.WriteLine("Source file path contains illegal chars -> Path changed to default: " + DEFAULT_SOURCE_PATH);
                }
                targetPath = args[1];
                format = args[2];
                try
                {
                    PathTest(targetPath);
                }
                catch(ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                    format = DEFAULT_FORMAT;
                    targetPath = DEFAULT_TARGET_PATH;
                    logsFile.WriteLine("Target file path contains illegal chars -> Path changed to default: " + DEFAULT_TARGET_PATH);
                }
               

            }
            else
            {

                csvPath = DEFAULT_SOURCE_PATH;
                targetPath = DEFAULT_TARGET_PATH;
                format = DEFAULT_FORMAT;


            }

            if (File.Exists(targetPath))
                File.Delete(targetPath);


            logsFile.Close();
            logsFile.Dispose();
        }

        static Boolean PathTest(String path)
        {
 
            char[] invalidChars = Path.GetInvalidPathChars();
            foreach (char letter in invalidChars)
            {
                if (path.Contains(letter))
                    throw new ArgumentException(String.Format("Argument contains illegal chars."));
            }

            return true;

        }
    }
}
