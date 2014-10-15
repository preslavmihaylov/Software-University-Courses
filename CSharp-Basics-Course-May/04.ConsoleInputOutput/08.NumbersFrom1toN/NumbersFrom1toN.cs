using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class NumbersFrom1toN
{
    static void Main()
    {
        Console.WriteLine("Input number:");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Result:");
        for (int count = 1; count <= number; count++)
        {
            Console.WriteLine(count);
        }
    }
}
