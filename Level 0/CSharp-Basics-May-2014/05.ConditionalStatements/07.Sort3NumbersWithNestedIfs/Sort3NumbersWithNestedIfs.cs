using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// not using arrays... So boring. Use Lists instead ^^

class Sort3NumbersWithNestedIfs
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
        numbers.Remove(biggestNumber);

        if (numbers[0] < numbers[1])
        {
            double temp = numbers[0];
            numbers[0] = numbers[1];
            numbers[1] = temp;
        }

        Console.WriteLine("Sorted: {0} {1} {2}", biggestNumber, numbers[0], numbers[1]);
    }
}
