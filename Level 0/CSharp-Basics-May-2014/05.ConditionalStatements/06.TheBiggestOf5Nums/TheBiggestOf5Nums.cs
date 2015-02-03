using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// using 5 if-clauses is too tedious

class TheBiggestOf5Nums
{
    static void Main()
    {
        double[] numbers = new double[5];
        

        for (int index = 0; index < numbers.Length; index++)
        {
            Console.WriteLine("Input number {0}", index + 1);
            double input = double.Parse(Console.ReadLine());
            numbers[index] = input;
        }

        double biggestNumber = int.MinValue;
        for (int index = 0; index < numbers.Length; index++)
        {
            if (biggestNumber < numbers[index])
            {
                biggestNumber = numbers[index];
            }
        }

        //Console.WriteLine(numbers.Max());

        Console.WriteLine(biggestNumber);
    }
}
