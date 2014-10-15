using System;
using System.Linq;
class HalfSum
{
    static void Main()
    {
        // the input from the console
        int inputCount = int.Parse(Console.ReadLine());
        int[] firstSqnc = new int[inputCount];
        int[] secondSqnc = new int[inputCount];
        for (int i = 0; i < inputCount; i++)
        {
            firstSqnc[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < inputCount; i++)
        {
            secondSqnc[i] = int.Parse(Console.ReadLine());
        }

        // using Linq, calculate the difference between the two sequences
        int result = 0;
        result = firstSqnc.Sum() - secondSqnc.Sum();
        if (result == 0)
        {
            Console.WriteLine("Yes, sum={0}", firstSqnc.Sum());
        }
            // since the result might be a negative value, use Math.Abs to turn it into a positive value in both cases
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(result));
        }
    }
}