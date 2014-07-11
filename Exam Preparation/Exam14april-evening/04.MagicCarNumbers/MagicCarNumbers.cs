using System;

class MagicCarNumbers
{
    static char[] letters = new char[10] { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };
    static int magicWeight = int.Parse(Console.ReadLine());
    static int count = 0;
    static void Main()
    {

        for (int num1 = 0; num1 <= 9; num1++)
        {
            for (int num2 = 0; num2 <= 9; num2++)
            {
                for (int letter1 = 0; letter1 < 10; letter1++)
                {
                    for (int letter2 = 0; letter2 < 10; letter2++)
                    {
                        int result = 40;
                        //string output = "CA";
                        result += CalcLetterWeight(letter1);
                        result += CalcLetterWeight(letter2);
                        CheckForResult(num1, num2, letter1, letter2, result);
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
    // !aaaa . !abbb . !aaab . !aabb . !abab . abba
    private static void CheckForResult(int num1, int num2, int letter1, int letter2, int result)
    {
        if (num1 == num2 && num1 * 4 + result == magicWeight)
        {
            count++;
        }
        if (num1 != num2)
        {
            if (num1 * 3 + num2 + result == magicWeight)
            {
                count++;
            }
            if (num2 * 3 + num1 + result == magicWeight)
            {
                count++;
            }
            if (num1 * 2 + num2 * 2 + result == magicWeight)
            {
                count += 3;
            }
        }
    }

    private static int CalcLetterWeight(int letter)
    {
        int tempResult = 0;
        switch (letter)
        {
            case 0:
                tempResult += 10;
                break;
            case 1:
                tempResult += 20;
                break;
            case 2:
                tempResult += 30;
                break;
            case 3:
                tempResult += 50;
                break;
            case 4:
                tempResult += 80;
                break;
            case 5:
                tempResult += 110;
                break;
            case 6:
                tempResult += 130;
                break;
            case 7:
                tempResult += 160;
                break;
            case 8:
                tempResult += 200;
                break;
            case 9:
                tempResult += 240;
                break;
        }
        return tempResult;
    }
}
