using System;

class MinMaxSumAverageOfNums
{
    static void Main()
    {
        int countOfNums = int.Parse(Console.ReadLine());
        int sum = 0;
        int max = int.MinValue;
        int min = int.MaxValue;
        double average = 0;

        for (int index = 0; index < countOfNums; index++)
        {
            int number = int.Parse(Console.ReadLine());

            average += number;
            sum += number;

            if (max < number)
            {
                max = number; 
            }

            if (min > number)
            {
                min = number;
            }
        }

        average /= countOfNums;

        Console.WriteLine("min = {0}", min);
        Console.WriteLine("max = {0}", max);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("average = {0:0.00}", average);
    }
}
