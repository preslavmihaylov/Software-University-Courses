using System;

class Student : Person
{
    private string type = "Student";
    private int studentID;
    private double averageGrade;

    public string Type
    {
        get
        {
            return this.type;    
        }
    }

    public int StudentID 
    {
        get
        {
            return this.studentID;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.studentID = value;
        }
    }

    public double AverageGrade
    {
        get
        {
            return this.averageGrade;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.averageGrade = value;
        }
    }

    public Student(string firstName, string lastName, int age, 
        int studentID, double averageGrade) : base(firstName, lastName, age)
    {
        this.StudentID = studentID;
        this.AverageGrade = Math.Round(averageGrade, 2);
    }

    public override string ToString()
    {
        string output = "";
        output += "Type: " + this.Type + Environment.NewLine;
        output += "Student ID: " + this.StudentID + Environment.NewLine;
        output += "Average Grade: " + this.AverageGrade + Environment.NewLine;
        return base.ToString() + output;
    }

}
