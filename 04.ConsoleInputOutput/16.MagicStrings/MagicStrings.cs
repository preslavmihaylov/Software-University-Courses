using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class MagicStrings
{
    public static List<string> magicStrings = new List<string>();
    static void Main()
    {
        int diff = int.Parse(Console.ReadLine());
        bool resultFound = false;

        for (int firstNum = 1; firstNum <= 5; firstNum++)
        {
            if (firstNum == 2)
            {
                continue;
            }

            for (int secondNum = 1; secondNum <= 5; secondNum++)
            {
                if (secondNum == 2)
                {
                    continue;
                }

                for (int thirdNum = 1; thirdNum <= 5; thirdNum++)
                {
                    if (thirdNum == 2)
                    {
                        continue;
                    }

                    for (int fourthNum = 1; fourthNum <= 5; fourthNum++)
                    {
                        if (fourthNum == 2)
                        {
                            continue;
                        }
                        int weight = 0;

                        if (firstNum + secondNum + thirdNum + fourthNum + diff <= 20)
                        {
                            weight = firstNum + secondNum + thirdNum + fourthNum + diff;
                            CalculateValue(firstNum, secondNum, thirdNum, fourthNum, weight);
                            resultFound = true;
                        }

                        if (firstNum + secondNum + thirdNum + fourthNum - diff >= 4 && diff != 0)
                        {
                            weight = firstNum + secondNum + thirdNum + fourthNum - diff;
                            CalculateValue(firstNum, secondNum, thirdNum, fourthNum, weight);
                            resultFound = true;
                        }
                    }
                }
            }
        }

        if (resultFound == false)
        {
            Console.WriteLine("No");
        }

        magicStrings.Sort();
        foreach (var item in magicStrings)
        {
            Console.WriteLine(item);
        }
    }

    public static void CalculateValue(int firstNum, int secondNum, int thirdNum, int fourthNum, int value)
    {
        for (int num1 = 1; num1 <= 5; num1++)
        {
            if (num1 == 2)
            {
                continue;
            }

            for (int num2 = 1; num2 <= 5; num2++)
            {
                if (num2 == 2)
                {
                    continue;
                }

                for (int num3 = 1; num3 <= 5; num3++)
                {
                    if (num3 == 2)
                    {
                        continue;
                    }

                    for (int num4 = 1; num4 <= 5; num4++)
                    {
                        if (num4 == 2)
                        {
                            continue;
                        }

                        if (num1 + num2 + num3 + num4 == value)
                        {
                            string magicString = "";

                            magicString += turnToMagicString(firstNum);
                            magicString += turnToMagicString(secondNum);
                            magicString += turnToMagicString(thirdNum);
                            magicString += turnToMagicString(fourthNum);
                            magicString += turnToMagicString(num1);
                            magicString += turnToMagicString(num2);
                            magicString += turnToMagicString(num3);
                            magicString += turnToMagicString(num4);

                            magicStrings.Add(magicString);
                        }
                    }

                }

            }
        }
    }

    public static string turnToMagicString(int number)
    {
        string temp = "";
        switch (number)
        {
            case 1:
                temp = "k";
                break;
            case 3:
                temp = "s";
                break;
            case 4:
                temp = "n";
                break;
            default:
                temp = "p";
                break;
        }
        return temp;
    }
}