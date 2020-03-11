using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace csvReaderXML.Models
{
    public class Student
    
    {

        String firstname, surname, studies, mode, email, motherName, fatherName;
        int index;
        DateTime date;
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

            return firstname + " ," + surname + " ," + index + " ," + motherName;

        }

        public bool Equals([AllowNull] Student y)
        {
            Console.WriteLine("a?");
            return (GetFirstName().Equals(y.GetFirstName()) && GetSurname().Equals(y.GetSurname()) 
                && GetIndex() == y.GetIndex());

        }
    }

}
