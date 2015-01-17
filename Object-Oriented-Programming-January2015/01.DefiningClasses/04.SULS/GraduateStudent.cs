using System;

class GraduateStudent : Student
{
    private string state = "Graduate";

    public string State
    {
        get
        {
            return this.state;    
        } 
    }

    public GraduateStudent(string firstName, string lastName, int age, 
        int studentID, double averageGrade) : base(firstName, lastName, age, studentID, averageGrade)
    {
    }

    public override string ToString()
    {
        return base.ToString() + "State: " + this.State + Environment.NewLine;
    }
}
