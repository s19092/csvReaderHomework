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

            String sourcePath,
                   targetPath,
                   format;
            if(args.Length == 3)
            {

                sourcePath = SetAsPath(args[0], DEFAULT_SOURCE_PATH);
                Console.WriteLine(sourcePath);
            }
            
        }


        public static void TestPath(string str)
        {

            char[] invalidPathChars = Path.GetInvalidPathChars();
            foreach (char letter in invalidPathChars)
            {

                if(str.Contains(letter))
                    throw new ArgumentException("Path contains invalid char code: " + (int)letter + "." );

            }
            Console.WriteLine("XD");

        }
        public static String SetAsPath(string str,string def)
        {

            try
            {

                TestPath(str);
                return str;

            }catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return def;
            }

        }

    }

}
