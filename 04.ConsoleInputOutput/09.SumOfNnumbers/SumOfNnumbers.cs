using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class SumOfNnumbers
{
    static void Main()
    {
        Console.WriteLine("How many numbers are to be input?");
        int numberOfInputs = int.Parse(Console.ReadLine());
        double result = 0;

        for (int index = 1; index <= numberOfInputs; index++)
        {
            Console.WriteLine("Input number {0}", index);
            double number = double.Parse(Console.ReadLine());
            result += number;
        }
        Console.WriteLine("Result: {0}", result);
    }
}
