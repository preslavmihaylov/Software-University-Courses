using System;
using System.Collections.Generic;
using System.Linq;
class OddEvenSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> oddNums = new List<int>();
        List<int> evenNums = new List<int>();

        int count = 0;
        for (int i = 0; i < n * 2; i++)
        {
            int number = int.Parse(Console.ReadLine());
            count++;
            if (count % 2 == 0)
            {
                evenNums.Add(number);
            }
            else
            {
                oddNums.Add(number);
            }
        }

        if (oddNums.Sum() == evenNums.Sum())
        {
            Console.WriteLine("Yes, sum={0}", oddNums.Sum());
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(oddNums.Sum() - evenNums.Sum()));
        }
    }
}
