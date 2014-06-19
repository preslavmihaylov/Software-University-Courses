using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class OddEvenSum
{
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();

        for (int count = 0; count < numberOfLines * 2; count++)
        {
            int number = int.Parse(Console.ReadLine());

            numbers.Add(number);
        }

        int evenNums = 0;
        int oddNums = 0;

        for (int index = 0; index < numbers.Count; index++)
        {
            if ((index + 1) % 2 == 0)
            {
                evenNums += numbers[index];
            }
            else
            {
                oddNums += numbers[index];
            }
        }

        if (evenNums == oddNums)
        {
            Console.WriteLine("Yes, sum={0}", evenNums);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(evenNums - oddNums));
        }
    }
}
