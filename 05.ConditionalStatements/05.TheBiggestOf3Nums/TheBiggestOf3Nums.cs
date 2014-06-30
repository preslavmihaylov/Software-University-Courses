using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TheBiggestOf3Nums
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

        double biggestNumber = int.MinValue;
        for (int index = 0; index < numbers.Count; index++)
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
