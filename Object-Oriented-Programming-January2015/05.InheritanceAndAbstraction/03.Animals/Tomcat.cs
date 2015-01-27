using System;

class Tomcat : Cat
{
    private string favouriteFood;

    public string FavouriteFood
    {
        get
        {
            return this.favouriteFood;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The favourite food cannot be null or empty");
            }
            this.favouriteFood = value;
        }
    }

    public Tomcat(string name, int age, string furColor = "Unknown",string favouriteFood = "Anything") : base(name, age, "Male", furColor)
    {
        this.FavouriteFood = favouriteFood;
    }
}
