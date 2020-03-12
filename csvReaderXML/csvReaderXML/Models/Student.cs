using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace csvReaderXML.Models
{

    public class Student
    
    {

        [XmlElement(elementName: "fname")]
        public String firstname { get; set; }

        [XmlElement(elementName: "lname")]
        public String surname { get; set; }

        [XmlElement(elementName: "studies")]
        public String studies { get; set; }

        [XmlElement(elementName: "mode")]
        public String mode { get; set; }

        [XmlElement(elementName: "email")]
        public String email { get; set; }

        [XmlElement(elementName: "motherName")]
        public String motherName { get; set; }

        [XmlElement(elementName: "fatherName")]
        public String fatherName { get; set; }

        [XmlElement(elementName: "index")]
        public int index { get; set; }

        [XmlElement(elementName: "birthdate")]
        public DateTime date { get; set; }
    
        public Student() { 
        }
        public Student(String firstName,string surname,string studies,string mode, int index, DateTime date
            ,String email,String motherName,String fatherName)
        {
            this.firstname = firstName;
            this.surname = surname;
            this.studies = studies;
            this.mode = mode;
            this.date = date;
            this.email = email;
            this.index = index;
            this.motherName = motherName;
            this.fatherName = fatherName;

        }

        public String GetSurname()
        {
            return surname;
        }

        public int GetIndex()
        {
            return index;
        }

        public String GetFirstName()
        {
            return surname;
        }



        public override String ToString()
        {

            return firstname + ", " + surname + ", " + index + ", " + motherName;

        }

        public bool Equals([AllowNull] Student y)
        {
            return (GetFirstName().Equals(y.GetFirstName()) && GetSurname().Equals(y.GetSurname()) 
                && GetIndex() == y.GetIndex());

        }
    }

}
