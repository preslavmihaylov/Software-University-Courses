using System;
using System.Collections.Generic;

class Discipline : IDetailable
{
    private string details;
    private string name;
    private int lecturesCount;
    private List<Student> students;

    public List<Student> Students
    {
        get
        {
            return this.students;
        }
    }

    public int LecturesCount
    {
        get
        {
            return this.lecturesCount;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.lecturesCount = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.name = value;
        }
    }

    public string Details
    {
        get
        {
            if (this.details == null)
            {
                return "No details";
            }
            else
            {
                return this.details;
            }
        }
        set
        {
            this.details = value;
        }
    }

    public Discipline(string name, int lecturesCount)
    {
        this.Name = name;
        this.LecturesCount = lecturesCount;
        this.students = new List<Student>();
    }

    public Discipline(string name, int lecturesCount, List<Student> students)
    {
        this.Name = name;
        this.LecturesCount = lecturesCount;
        this.students = students;
    }

    public override string ToString()
    {
        string output = "";
        output += "Name: " + this.Name + Environment.NewLine;
        output += "Details: " + this.Details + Environment.NewLine;
        output += "Lectures Count: " + this.LecturesCount + Environment.NewLine;
        output += "Students:" + Environment.NewLine;

        foreach (var student in this.students)
        {
            output += new string(' ', 5) + student.ToString() + Environment.NewLine;
        }
        return output;
    }
}
