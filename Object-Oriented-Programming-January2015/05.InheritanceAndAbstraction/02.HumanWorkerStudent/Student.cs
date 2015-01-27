using System;
using System.Text.RegularExpressions;
class Student : Human
{
    private string facultyNumber;
    private Regex facultyMatcher = new Regex("[0-9a-zA-Z]{5,10}");

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }
        private set
        {
            if (!facultyMatcher.IsMatch(value))
            {
                throw new ArgumentException("The input number doesn't match the proper expression. 5-10 digits/letters");
            }
            this.facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }
}
