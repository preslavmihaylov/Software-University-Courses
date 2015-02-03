using System;
class CurrentStudent : Student
{
    private string state = "Active";
    private string currentCourse;

    public string State
    {
        get
        {
            return this.state;    
        } 
    }

    public string CurrentCourse
    {
        get
        {
            return this.currentCourse;
        }

        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.currentCourse = value;
        }
    }

    public CurrentStudent(string firstName, string lastName, int age, 
        int studentID, double averageGrade, 
        string currentCourse = "Missing info") : base(firstName, lastName, age, studentID, averageGrade)
    {
        this.CurrentCourse = currentCourse;
    }

    public override string ToString()
    {
        string output = "";
        output += "State: " + this.State + Environment.NewLine;
        output += "Current Course: " + this.CurrentCourse + Environment.NewLine;
        return base.ToString() + output;
    }
}
