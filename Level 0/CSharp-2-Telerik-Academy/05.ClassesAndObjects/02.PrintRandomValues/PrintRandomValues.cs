using System;
class PrintRandomValues
{
    static Random randGenerator = new Random();
    static void Main()
    {
        for (int index = 0; index < 10; index++)
        {
            Console.WriteLine(randGenerator.Next(100, 201));
        }
    }
}
