using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class NumberComparer
{
    static void Main()
    {
        Console.WriteLine("Input number 1:");
        double number1 = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Input number 2:");
        double number2 = double.Parse(Console.ReadLine());
        

        Console.WriteLine("The greater number is: {0}", Math.Max(number1, number2));
    }
}
