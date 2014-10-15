using System;
using System.Collections.Generic;

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        List<long> elements = new List<long>();

        while (number > 16)
        {
            elements.Add(number % 16);
            number /= 16;
        }
        elements.Add(number);

        string output = "";

        for (int index = elements.Count - 1; index >= 0; index--)
        {
            switch (elements[index])
            {
                case 10:
                    output += "A";
                    break;
                case 11:
                    output += "B";
                    break;
                case 12:
                    output += "C";
                    break;
                case 13:
                    output += "D";
                    break;
                case 14:
                    output += "E";
                    break;
                case 15:
                    output += "F";
                    break;
                default:
                    output += elements[index];
                    break;
            }
        }

        Console.WriteLine(output);
    }
}
