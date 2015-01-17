using System;

class DropoutStudent : Student
{
    private string state = "Dropout";
    private string dropoutReason;

    public string State
    {
        get
        {
            return this.state;    
        }
    }

    public string DropoutReason
    {
        get
        {
            return this.dropoutReason;
        }

        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.dropoutReason = value;
        }
    }

    public DropoutStudent(string firstName, string lastName, int age,
        int studentID, double averageGrade, string dropoutReason = "Missing info") : base(firstName, lastName, age, studentID, averageGrade)
    {
        this.DropoutReason = dropoutReason;
    }

    public void reapply()
    {
        Console.WriteLine("The student " + this.FirstName + " " + this.LastName + " has reapplied.");
    }

    public override string ToString()
    {
        string output = "";
        output += "State: " + this.State + Environment.NewLine;
        output += "Dropout reason: " + this.DropoutReason + Environment.NewLine;
        return base.ToString() + output;
    }
}
