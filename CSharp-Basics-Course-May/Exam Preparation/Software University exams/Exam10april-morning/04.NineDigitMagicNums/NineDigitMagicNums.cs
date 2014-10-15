using System;
using System.Collections.Generic;
using System.Linq;
class MagicNums
{
    static void Main()
    {
        // initial input
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        // a boolean variable in order to check if there is any result found
        bool resultFound = false;

        // since every other set of numbers from the magic number is exactly (previous set + diff), 
        // there is no need to use any other loops for every set of numbers
        for (int num1 = 111; num1 <= 777; num1++)
        {
            int num2 = num1 + diff;
            int num3 = num2 + diff;

            // in order to avoid using 7 nested loops, I used this complex condition.
            // basically, it checks every set of numbers to contain digits exactly from 1 to 7.
            // surely, there is a far more simple way to do this, but I am kind of dumb and lazy. :)
            if (num1 % 10 == 0 || (num1 / 10) % 10 == 0 ||
                num2 % 10 == 0 || (num2 / 10) % 10 == 0 ||
                num3 % 10 == 0 || (num3 / 10) % 10 == 0 ||
                num1 % 10 > 7 || (num1 / 10) % 10 > 7 ||
                num2 % 10 > 7 || (num2 / 10) % 10 > 7 ||
                num3 % 10 > 7 || (num3 / 10) % 10 > 7 ||
                num2 > 777 || num3 > 777)
            {
                continue;
            }
            List<int> sumOfNums = new List<int>();
            int result = 0;

            // check the sum of the digits for each set of numbers
            GetDigitsFromNum(num1, sumOfNums);
            result += sumOfNums.Sum();

            GetDigitsFromNum(num2, sumOfNums);
            result += sumOfNums.Sum();

            GetDigitsFromNum(num3, sumOfNums);
            result += sumOfNums.Sum();

            if (result == sum)
            {
                Console.WriteLine("{0}{1}{2}", num1, num2, num3);
                resultFound = true;
            }
        }

        if (resultFound == false)
        {
            Console.WriteLine("No");
        }
    }

    static void GetDigitsFromNum(int number, List<int> listOfNums)
    {
        // clear list for the next set of numbers
        listOfNums.Clear();
        while (number > 0)
        {
            // insert each digit from the number to the list
            listOfNums.Add(number % 10);
            number /= 10;
        }
    }
}
