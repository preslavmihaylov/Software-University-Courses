using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MultiplicationSign
{
    static void Main()
    {
        List<double> numbers = new List<double>();

        for (int index = 1; index <= 3; index++)
        {
            Console.WriteLine("Input number {0}", index);
            double input = double.Parse(Console.ReadLine());
            numbers.Add(input);
        }

        if (numbers[0] == 0 || numbers[1] == 0 || numbers[2] == 0)
        {
            Console.WriteLine("Result: 0");
            return;
        }

        int negativeCount = 0;
        for (int index = 0; index < 3; index++)
        {
            if (numbers[index] < 0)
            {
                negativeCount++;
            }
        }

        if (negativeCount == 1 || negativeCount == 3)
        {
            Console.WriteLine("Result: -");
        }
        else
        {
            Console.WriteLine("Result: +");
        }
    }
}
