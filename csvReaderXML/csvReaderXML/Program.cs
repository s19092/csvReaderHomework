using csvReaderXML.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

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
                    Dictionary<String, List<Student>> map = new Dictionary<string, List<Student>>();
                    for (String line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {

                        Student stud = createStudent(line.Split(','));
                        if (stud != null)
                        {
                            bool isAdded = students.Add(stud);
                            if (!isAdded)
                                logs.WriteLine("Value not unique: " + stud);
                            else
                            {
                                map.Add(stud.studies, new List<Student>());

                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid value.");
                        }
                    }
                    reader.Dispose();



                    FileStream writer = new FileStream(targetPath, FileMode.Create);

                    String dateT = DateTime.Now.ToString("dd.MM.yyy");

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml("<uczelnia></uczelnia>");
                    XmlElement root = doc.DocumentElement;
                    root.SetAttribute("createdAt", dateT);
                    root.SetAttribute("author", "Piotr Adarczyn");
                    XmlNode e = doc.CreateElement("studenci");
                    foreach (Student s in students.GetData())
                    {

                        e.AppendChild(CreateStudXml(s,doc));

                    }
                    XmlNode activiaActireguralis = doc.CreateElement("activeStudies");
                    XmlElement studiesName = doc.CreateElement("studies");
                    foreach (KeyValuePair<string, List<Student>> entry in map)
                    {
                        studiesName.SetAttribute("name",(String.Join("",entry.Value.Count)));
                    }
                    



                    root.AppendChild(e);



                    doc.Save(writer);
                    writer.Dispose();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    doc.Save(Console.Out);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();


                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    logs.WriteLine(e.Message);
                }


                
               

            }
            logs.Dispose();
        }

        public static XmlElement CreateStudXml(Student stud,XmlDocument doc)
        {

            XmlElement result = doc.CreateElement("student");
            String index = "s" + stud.index;
            
            result.SetAttribute("indexNumber", index);
            
           
            XmlElement firstName = doc.CreateElement("fname");
            firstName.InnerText = stud.firstname;
            result.AppendChild(firstName);

            XmlElement surName = doc.CreateElement("lname");
            surName.InnerText = stud.surname;
            result.AppendChild(surName);

            XmlElement birb = doc.CreateElement("birthdate");
            birb.InnerText = stud.date.ToString("dd.MM.yyy");
            result.AppendChild(birb);

            XmlElement email = doc.CreateElement("email");
            email.InnerText = stud.email;
            result.AppendChild(email);


            XmlElement motherN = doc.CreateElement("mothersName");
            motherN.InnerText = stud.motherName;
            result.AppendChild(motherN);

            XmlElement fatherN = doc.CreateElement("fathersName");
            fatherN.InnerText = stud.fatherName;
            result.AppendChild(fatherN);

            XmlNode studies = doc.CreateElement("studies");
            XmlElement name = doc.CreateElement("name");
            name.InnerText = stud.studies;
            
            XmlElement mode = doc.CreateElement("mode");
            mode.InnerText = stud.mode;


            studies.AppendChild(name);
            studies.AppendChild(mode);
            result.AppendChild(studies);

            return result;

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
