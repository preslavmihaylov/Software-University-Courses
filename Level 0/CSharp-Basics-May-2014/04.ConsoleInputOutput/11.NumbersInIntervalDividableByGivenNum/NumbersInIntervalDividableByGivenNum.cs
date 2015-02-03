using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class NumbersInIntervalDividableByGivenNum
{
    static void Main()
    {
        Console.WriteLine("Input first number");
        int firstNum = int.Parse(Console.ReadLine());
        Console.WriteLine("Input second number");
        int secondNum = int.Parse(Console.ReadLine());
        bool resultFound = false;

        int count = 0;
        for (int index = firstNum; index <= secondNum; index++)
        {
            if (index % 5 == 0)
            {
                count++;
                resultFound = true;
            }
        }

        if (resultFound == true)
        {
            Console.WriteLine("Result: {0}", count);
        }
        else
        {
            Console.WriteLine("-");
        }
    }
}
