using System;

class Individual : Customer
{
    private string ucn; // Unique Citizen Identifier

    public string UCN
    {
        get
        {
            return this.ucn;
        }
        set
        {
            if (value.Length != 10)
            {
                throw new ArgumentException();
            }
            this.ucn = value;
        }
    }

    public Individual(string name, int age, string ucn) : base(name, age)
    {
        this.UCN = ucn;
    }
}