using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CA_EX_2
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Year { get; set; }

        public Student(string firstName, string lastName, int year)
        {
            FirstName = firstName;
            LastName = lastName;
            Year = year;
        }
        public override string ToString()
        {
            return string.Format($"{LastName}, {FirstName} - Year{Year}");
        }
    }
}
