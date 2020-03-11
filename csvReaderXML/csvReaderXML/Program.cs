using csvReaderXML.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace csvReaderXML
{
    class Program
    {


        static StreamWriter logs = new StreamWriter(@"logs.txt");
        static String DEFAULT_SOURCE_PATH = "data.csv";
        static String DEFAULT_TARGET_PATH = "result.xml";
        static String DEFAULT_FORMAT = "xml";
        static void Main(string[] args)
        {

            String sourcePath,
                   targetPath,
                   format;
            if (args.Length == 3)
            {

                sourcePath = SetAsPath(args[0], DEFAULT_SOURCE_PATH);
                targetPath = SetAsPath(args[1], DEFAULT_TARGET_PATH);
                format = args[2];

            }
            else
            {
                sourcePath = DEFAULT_SOURCE_PATH;
                targetPath = DEFAULT_TARGET_PATH;
                format = DEFAULT_FORMAT;
            }

            FileInfo f = null;

            try
            {
                f = new FileInfo(sourcePath);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                logs.WriteLine(e.Message);
            }

            if (f != null)
            {
                try
                {
                    StreamReader reader = new StreamReader(f.OpenRead());
                    HashSet<Student> students = new HashSet<Student>();
                    for (String line = reader.ReadLine(); line != null; line = reader.ReadLine())
                        

                    reader.Dispose();
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    logs.WriteLine(e.Message);
                }


                
               

            }
            logs.Dispose();
        }

        public static Student createStudent(string[] array)
        {
            if (array.Length != 9)
            {

                logs.WriteLine("Invalid row: ");
                foreach (String val in array)
                {

                }

            }
            Student result = new Student();
            return result;

        }
        public static void TestPathChars(string str)
        {

            char[] invalidPathChars = Path.GetInvalidPathChars();
            foreach (char letter in invalidPathChars)
            {

                if(str.Contains(letter))
                    throw new ArgumentException("Path contains invalid char code: " + (int)letter + "." );

            }
       

        }
        public static String SetAsPath(string str,string def)
        {

            try
            {

                TestPathChars(str);
                return str;

            }catch(ArgumentException e)
            {
                logs.WriteLine(e.Message);
                Console.WriteLine(e.Message);
                return def;
            }

        }
        public static void TestPathDestination(string str)
        {

            

        }

    }

}
