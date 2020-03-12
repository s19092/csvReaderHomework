using csvReaderXML.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace csvReaderXML
{
    class StudentsSet
    {

        [XmlElement(elementName: "XDD")]
        List<Student> data = new List<Student>();

        public bool Add(Student stud)
        {

            bool valid = true;
            foreach(Student s in data)
            {

                if (s.Equals(stud))
                {
                    valid = false;
                    break;
                }

            }
            if (valid)
                data.Add(stud);
            return valid;

        }
        public List<Student> GetData()
        {
            return data;
        }



    }
}
