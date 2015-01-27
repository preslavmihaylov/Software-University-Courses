using System;

class Dog : Animal, ISound
{
    private string breed;

    public string Breed
    {
        get
        {
            return this.breed;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The breed cannot be null or empty. Use Pomyar instead.");
            }
            this.breed = value;
        }
    }

    public Dog(string name, int age, string gender, string breed) : base(name, age, gender)
    {
        this.Breed = breed;
    }

    public void ProduceSound()
    {
        Console.WriteLine("Woof! Woof!");
    }
}
