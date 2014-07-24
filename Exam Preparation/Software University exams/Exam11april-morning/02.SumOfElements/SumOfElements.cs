using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class SumOfElements
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        List<long> numbers = new List<long>();

        for (int index = 0; index < input.Length; index++)
        {
            numbers.Add(Convert.ToInt64(input[index]));
        }

        long maxNum = numbers.Max();

        numbers.Remove(numbers.Max());

        if (numbers.Sum() == maxNum)
        {
            Console.WriteLine("Yes, sum={0}", maxNum);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(numbers.Sum() - maxNum));
        }
    }
}
