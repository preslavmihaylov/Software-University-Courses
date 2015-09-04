namespace _01.StudentsAndCourses
{
    using System;

    class Student : IComparable<Student>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        public int CompareTo(Student other)
        {
            return this.LastName.CompareTo(other.LastName);
        }
    }
}