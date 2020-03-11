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
                    StudentsSet students = new StudentsSet();
                    for (String line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                      
                        Student stud = createStudent(line.Split(','));
                        if (stud != null)
                        {
                            bool isAdded = students.Add(stud);
                            if (!isAdded)
                                logs.WriteLine("Value not unique: " + stud);
                        }
                        else
                        {
                            Console.WriteLine("Invalid value.");
                        }
                    }

                    foreach (Student s in students.GetData())
                    {
                        Console.WriteLine(s);

                    }
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

                logs.Write("Invalid row: ");
                foreach (String val in array)
                {
                    logs.Write(val + ", ");
                }
                return null;
            }else{
                bool valid = true;
                foreach(String val in array)
                {
                    if (val.Equals(""))
                        valid = false;
                }
                if (valid)
                {
                    DateTime date;
                 
                    if (DateTime.TryParse(array[5], out date)){
                        try
                        {
                            return new Student(array[0], array[1], array[2], array[3], Int32.Parse(array[4]), date
                                , array[6], array[7], array[8]);
                        }catch(FormatException e)
                        {
                            Console.WriteLine(e.Message);
                            logs.WriteLine(e.Message);
                            return null;
                        }
                    }
                    else
                    {
                        logs.WriteLine("Wrong date format.");
                        return null;
                    }
                }
                else
                {
                    logs.WriteLine("Empty values in: " + string.Join(", ",array));
                    return null;
                }
                

            }

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
       

    }

}
