using System;

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        string input = Console.ReadLine();

        int position = 0;
        long result = 0;

        for (int index = input.Length - 1; index >= 0; index--)
        {
            int number;
            switch (input[index])
            {
                case 'A':
                    number = 10;
                    break;
                case 'B':
                    number = 11;
                    break;
                case 'C':
                    number = 12;
                    break;
                case 'D':
                    number = 13;
                    break;
                case 'E':
                    number = 14;
                    break;
                case 'F':
                    number = 15;
                    break;
                default:
                    number = Convert.ToInt32(Convert.ToString(input[index]));
                    break;
            }

            result += (long)(number * Math.Pow(16, position));
            position++;
        }

        Console.WriteLine(result);
    }
}
