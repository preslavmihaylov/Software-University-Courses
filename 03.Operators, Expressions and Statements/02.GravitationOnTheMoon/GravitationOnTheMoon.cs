using System;
using System.Collections.Generic;

//Problem 2.	Gravitation on the Moon
//The gravitational field of the Moon is approximately 17% of that on the Earth. 
//Write a program that calculates the weight of a man on the moon by a given weight on the Earth. 

class GravitationOnTheMoon
{
    static void Main()
    {
        double input = double.Parse(Console.ReadLine());
        

        double weightOnMoon = (17 * input) / 100;
        Console.WriteLine(weightOnMoon);
    }
}
