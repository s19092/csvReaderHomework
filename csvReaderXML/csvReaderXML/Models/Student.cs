using System;
using System.Diagnostics.CodeAnalysis;

namespace csvReaderXML.Models
{
    public class Student
        : IEquatable<Student>
    {

        String firstname, surname, studies, mode, email, motherName, fatherName;
        int index;
        DateTime date;
        public Student() { 
        }
        public Student(String firstName,string surname,string studies,string mode,, int index, DateTime date
            ,String email,String motherName,String fatherName)
        {
            this.firstname = firstName;
            this.surname = surname;
            this.studies = studies;
            this.mode = mode;
            this.date = date;
            this.email = email;
            this.motherName = motherName;
            this.fatherName = fatherName;

        }


        public bool Equals( Student other)
        {
            Console.WriteLine("EKUAL");
            if (this.firstname.Equals(other.firstname) && this.surname.Equals(other.surname) && this.index == other.index)
                return true;
            return false;
        }
    }
}
