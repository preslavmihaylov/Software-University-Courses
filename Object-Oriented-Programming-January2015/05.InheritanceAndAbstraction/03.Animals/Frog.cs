using System;

class Frog : Animal, ISound
{
    private string color;

    public string Color
    {
        get
        {
            return this.color;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The color cannot be null or empty");
            }
            this.color = value;
        }
    }

    public Frog(string name, int age, string gender, string color) : base(name, age, gender)
    {
        this.Color = color;
    }

    public void ProduceSound()
    {
        Console.WriteLine("Ribbbit! Ribbbit!");
    }
}
