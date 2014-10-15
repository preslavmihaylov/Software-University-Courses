using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class OddEvenElements
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        List<decimal> oddElements = new List<decimal>();
        List<decimal> evenElements = new List<decimal>();

        for (int index = 0; index < input.Length; index++)
        {
            if (input[index] != "")
            {
                decimal number = Convert.ToDecimal(input[index]);
                if ((index + 1) % 2 == 0)
                {
                    evenElements.Add(number);
                }
                else
                {
                    oddElements.Add(number);
                }
            }
        }

        string oddSum = "No";
        string oddMin = "No";
        string oddMax = "No";

        string evenSum = "No";
        string evenMin = "No";
        string evenMax = "No";

        if (oddElements.Count > 0)
        {
            oddSum = Convert.ToString(Normalize(oddElements.Sum()));
            oddMin = Convert.ToString(Normalize(oddElements.Min()));
            oddMax = Convert.ToString(Normalize(oddElements.Max()));
        }

        if (evenElements.Count > 0)
        {
            evenSum = Convert.ToString(Normalize(evenElements.Sum()));
            evenMin = Convert.ToString(Normalize(evenElements.Min()));
            evenMax = Convert.ToString(Normalize(evenElements.Max()));
        }

        Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
            oddSum, oddMin, oddMax, evenSum, evenMin, evenMax);
    }

    public static decimal Normalize(decimal value)
    {
        return value / 1.000000000000000000000000000000000m;
    }
}
