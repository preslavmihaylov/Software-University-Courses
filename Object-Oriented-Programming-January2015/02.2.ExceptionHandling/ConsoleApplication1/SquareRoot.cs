using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Sqrt(number));
        }
        catch (Exception)
        {

            Console.WriteLine("Invalid number.");
        }
        finally
        {
            Console.WriteLine("Goodbye");
        }
    }
}
