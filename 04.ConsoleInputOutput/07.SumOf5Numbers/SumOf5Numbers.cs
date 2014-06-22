using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class SumOf5Numbers
{
    static void Main()
    {
        Console.WriteLine("Input numbers on a single line:");
        string[] input = Console.ReadLine().Split();
        List<double> numbers = new List<double>();

        for (int index = 0; index < input.Length; index++)
        {
            numbers.Add(Convert.ToDouble(input[index]));
        }

        Console.WriteLine("Result: {0}", numbers.Sum());
    }
}
