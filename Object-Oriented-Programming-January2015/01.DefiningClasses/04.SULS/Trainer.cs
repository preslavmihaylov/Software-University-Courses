using System;
class Trainer : Person
{
    private string type = "Trainer";

    public string Type
    {
        get
        {
            return this.type;    
        }    
    }
    public Trainer(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {
    }

    public void createCourse(string courseName)
    {
        Console.WriteLine("The trainer " + this.FirstName + " " + this.LastName + " has created the course " + courseName);
    }

    public override string ToString()
    {
        return base.ToString() + "Type: " + this.Type + Environment.NewLine;
    }
}
