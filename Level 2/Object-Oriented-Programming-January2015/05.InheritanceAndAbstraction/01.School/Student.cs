using System;
using System.Collections.Generic;

class Student : Person, IDetailable
{
    static List<int> usedClassNumbers = new List<int>();
    private int classNumber;

    public int ClassNumber
    {
        get
        {
            return this.classNumber;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            else if (usedClassNumbers.Contains(value))  
            {
                throw new ArgumentException("The student number has already been used.");
            }
            this.classNumber = value;
            Student.usedClassNumbers.Add(value);
        }
    }

    public Student(string name, int age, int classNumber, string details = null) : base(name, age, details)
    {
        this.ClassNumber = classNumber;
    }

    public override string ToString()
    {
        string output = "";
        output += "Class Number: " + this.ClassNumber + Environment.NewLine;
        return base.ToString() + output;
    }
}
