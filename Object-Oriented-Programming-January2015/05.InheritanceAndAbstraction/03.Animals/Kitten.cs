using System;

class Kitten : Cat
{
    private string hornyMonth;

    public string HornyMonth
    {
        get
        {
            return this.hornyMonth;
        }
        set
        {
            if (value != "January" && value != "February" && value != "March" && value != "April" && value != "May" &&
                value !="June" && value !="July" && value != "August" && value !="September" && value !="October" && 
                value != "November" && value!="December")
            {
                throw new ArgumentException("The horny month must be a valid month.");
            }
            this.hornyMonth = value;
        }
    }

    public Kitten(string name, int age, string hornyMonth) : base(name, age, "Female")
    {
        this.HornyMonth = hornyMonth;
    }

    public Kitten(string name, int age, string furColor, string hornyMonth) : base(name, age, "Female", furColor)
    {
        this.HornyMonth = hornyMonth;
    }
}
