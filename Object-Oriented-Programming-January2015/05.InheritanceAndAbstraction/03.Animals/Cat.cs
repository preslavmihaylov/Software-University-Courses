using System;

abstract class Cat : Animal, ISound
{
    private string furColor;

    public string FurColor
    {
        get
        {
            return this.furColor;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The color cannot be null or empty.");
            }
            this.furColor = value;
        }
    }

    public Cat(string name, int age, string gender, string furColor = "Unknown") : base(name, age, gender)
    {
        this.FurColor = furColor;
    }

    public void ProduceSound()
    {
        Console.WriteLine("Meoooow");
    }
}
