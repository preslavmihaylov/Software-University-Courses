using System;

class OnsiteStudent : CurrentStudent
{
    private string form = "Onsite";
    private int numberOfVisits;

    public string Form
    {
        get
        {
            return this.form;    
        }    
    }

    public int NumberOfVisits
    {
        get
        {
            return this.numberOfVisits;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.numberOfVisits = value;
        }
    }

    public OnsiteStudent(string firstName, string lastName, int age,
        int studentID, double averageGrade,
        string currentCourse = "Missing info", 
        int numberOfVisits = 0) : base(firstName, lastName, age, studentID, averageGrade, currentCourse)
    {
        this.NumberOfVisits = numberOfVisits;
    }

    public override string ToString()
    {
        string output = "";
        output += "Form: " + this.Form + Environment.NewLine;
        output += "Number of visits: " + this.NumberOfVisits + Environment.NewLine;
        return base.ToString() + output;
    }
}
