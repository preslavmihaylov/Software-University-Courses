using System;
using System.Collections.Generic;

class Class : IDetailable
{
    static List<string> usedUniqueIDs = new List<string>();
    private List<Student> students;
    private List<Teacher> teachers;
    private string details;
    private string uniqueID;

    public List<Student> Students
    {
        get
        {
            return this.students;
        }
    }

    public List<Teacher> Teachers
    {
        get
        {
            return this.teachers;
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

    public string UniqueID
    {
        get
        {
            return this.uniqueID;
        }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException();
            }
            else if (Class.usedUniqueIDs.Contains(value))
            {
                throw new ArgumentException("That ID has already been used.");
            }
            this.uniqueID = value;
        }
    }

    public Class(string uniqueID, string details = null)
    {
        this.UniqueID = uniqueID;
        this.students = new List<Student>();
        this.teachers = new List<Teacher>();
        this.Details = details;
    }

    public Class(string uniqueID, List<Student> students, List<Teacher> teachers, string details = null)
    {
        this.UniqueID = uniqueID;
        this.students = students;
        this.teachers = teachers;
        this.Details = details;
    }

    public Class(string uniqueID, List<Student> students, string details = null)
    {
        this.UniqueID = uniqueID;
        this.students = students;
        this.teachers = new List<Teacher>();
        this.Details = details;
    }

    public Class(string uniqueID, List<Teacher> teachers, string details = null)
    {
        this.UniqueID = uniqueID;
        this.students = new List<Student>();
        this.teachers = teachers;
        this.Details = details;
    }

    public override string ToString()
    {
        string output = "";
        output += "Unique ID: " + this.UniqueID + Environment.NewLine;
        output += "Details: " + this.Details + Environment.NewLine;
        output += Environment.NewLine;
        output += "Students attending: " + Environment.NewLine;

        foreach (var student in this.students)
        {
            output += new string(' ', 5) + student.ToString();
            output += Environment.NewLine;
        }
        output += Environment.NewLine;
        output += "Teachers: " + Environment.NewLine;
        foreach (var teacher in this.teachers)
        {
            output += new string(' ', 5) + teacher.ToString();
            output += Environment.NewLine;
        }
        return output;
    }
}
