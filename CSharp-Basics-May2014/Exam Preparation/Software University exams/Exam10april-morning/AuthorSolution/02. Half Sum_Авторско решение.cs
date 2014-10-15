using System;

class HalfSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum1 = 0;
        for (int i = 0; i < n; i++)
        {
            int element = int.Parse(Console.ReadLine());
            sum1 = sum1 + element;
        }
        int sum2 = 0;
        for (int i = 0; i < n; i++)
        {
            int element = int.Parse(Console.ReadLine());
            sum2 = sum2 + element;
        }

        if (sum1 == sum2)
        {
            Console.WriteLine("Yes, sum=" + sum1);
        }
        else
        {
            int diff = Math.Abs(sum1 - sum2);
            Console.WriteLine("No, diff=" + diff);
        }
    }
}
