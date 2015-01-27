using System;
using System.Linq;

class AnimalsDemo
{
    static void Main()
    {
        Cat[] cats = new Cat[5];
        cats[0] = new Tomcat("Murry", 2);
        cats[1] = new Kitten("Glori", 4, "January");
        cats[2] = new Tomcat("Ico", 3, "Orange", "Mice");
        cats[3] = new Kitten("Katya", 2, "March");
        cats[4] = new Tomcat("Tom", 5);

        Console.WriteLine("The average age of the cats is: " + cats.Average(c => c.Age));

        Dog doggy = new Dog("Persin", 6, "Male", "English Pointer");
        doggy.ProduceSound();
    }
}
