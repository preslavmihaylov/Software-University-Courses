using System;
using System.Linq;
class HayvanNums
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        bool resultFound = false;

        for (int firstNum = 555; firstNum <= 999; firstNum++)
        {
            int secondNum = firstNum + diff;
            int thirdNum = secondNum + diff;

            if (firstNum % 10 < 5 || (firstNum / 10) % 10 < 5 ||
                secondNum % 10 < 5 || (secondNum / 10) % 10 < 5 ||
                thirdNum % 10 < 5 || (thirdNum / 10) % 10 < 5)
            {
                continue;
            }
            if (secondNum < 1000 && thirdNum < 1000)
            {
                string stringNums = Convert.ToString(firstNum);
                stringNums += Convert.ToString(secondNum);
                stringNums += Convert.ToString(thirdNum);
                int[] digits = new int[stringNums.Length];

                for (int i = 0; i < stringNums.Length; i++)
                {
                    digits[i] = Convert.ToInt32(Convert.ToString(stringNums[i]));
                }

                if (digits.Sum() == sum)
                {
                    resultFound = true;
                    Console.WriteLine("{0}{1}{2}", firstNum, secondNum, thirdNum);
                }
            }

        }

        if (resultFound == false)
        {
            Console.WriteLine("No");
        }
    }
}
