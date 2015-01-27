using System;

class Company : Customer
{
    private string bulstat;

    public string Bulstat
    {
        get
        {
            return this.bulstat;
        }
        set
        {
            this.bulstat = value;
        }
    }

    public Company(string name, int age, string bulstat) : base(name, age) 
    {
        this.Bulstat = bulstat;
    }
}
