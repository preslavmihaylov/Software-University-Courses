using System;

class OnlineStudent : CurrentStudent
{
    private string form = "Online";

    public string Form
    {
        get
        {
            return this.form;    
        } 
    }

    public OnlineStudent(string firstName, string lastName, int age,
        int studentID, double averageGrade,
        string currentCourse = "Missing info") : base(firstName, lastName, age, studentID, averageGrade, currentCourse)
    {
    }

    public override string ToString()
    {
        return base.ToString() + "Form: " + this.Form + Environment.NewLine;
    }
}
