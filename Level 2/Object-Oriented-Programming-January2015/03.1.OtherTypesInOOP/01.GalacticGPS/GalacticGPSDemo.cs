using System;

class GalacticGPSDemo
{
    static void Main()
    {
        Location earth = new Location(2, 2.2, (Planet)6);
        Console.WriteLine(earth);
        Console.WriteLine(++earth.Longtitude);
    }
}
