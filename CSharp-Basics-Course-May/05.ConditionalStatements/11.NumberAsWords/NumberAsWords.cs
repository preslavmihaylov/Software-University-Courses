using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NumberAsWords
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool units = false;
        bool tens = false;
        bool hundreds = false;

        if (number > 999 || number < 0)
        {
            Console.WriteLine("Invalid number");
            return;
        }
        if (number % 10 > 0)
        {
            units = true;
        }
        if ((number / 10) % 10 > 0)
        {
            tens = true;
        }
        if ((number / 100) % 10 > 0)
        {
            hundreds = true;
        }

        string output = "";

        if (hundreds)
        {
            switch ((number / 100) % 10)
            {
                case 1:
                    output += "one hundred";
                    break;
                case 2:
                    output += "two hundred";
                    break;
                case 3:
                    output += "three hundred";
                    break;
                case 4:
                    output += "four hundred";
                    break;
                case 5:
                    output += "five hundred";
                    break;
                case 6:
                    output += "six hundred";
                    break;
                case 7:
                    output += "seven hundred";
                    break;
                case 8:
                    output += "eight hundred";
                    break;
                case 9:
                    output += "nine hundred";
                    break;
            }
        }

        if (hundreds && (tens || units))
        {
            output += " and ";
        }

        if (tens)
        {
            switch ((number / 10) % 10)
            {
                case 2:
                    output += "twenty ";
                    break;
                case 3:
                    output += "thirty ";
                    break;
                case 4:
                    output += "fourty ";
                    break;
                case 5:
                    output += "fifty ";
                    break;
                case 6:
                    output += "sixty ";
                    break;
                case 7:
                    output += "seventy ";
                    break;
                case 8:
                    output += "eighty ";
                    break;
                case 9:
                    output += "ninety ";
                    break;
            }
        }

        if ((number / 10) % 10 != 1 && units)
        {
            switch (number % 10)
            {
                case 1:
                    output += "one";
                    break;
                case 2:
                    output += "two";
                    break;
                case 3:
                    output += "three";
                    break;
                case 4:
                    output += "four";
                    break;
                case 5:
                    output += "five";
                    break;
                case 6:
                    output += "six";
                    break;
                case 7:
                    output += "seven";
                    break;
                case 8:
                    output += "eight";
                    break;
                case 9:
                    output += "nine";
                    break;
            }
        }
        else if ((number / 10) % 10 == 1)
        {
            switch (number % 10)
            {
                case 0:
                    output += "ten";
                    break;
                case 1:
                    output += "eleven";
                    break;
                case 2:
                    output += "twelve";
                    break;
                case 3:
                    output += "thirteen";
                    break;
                case 4:
                    output += "fourteen";
                    break;
                case 5:
                    output += "fifteen";
                    break;
                case 6:
                    output += "sixteen";
                    break;
                case 7:
                    output += "seventeen";
                    break;
                case 8:
                    output += "eighteen";
                    break;
                case 9:
                    output += "nineteen";
                    break;
            }
        }

        if (output == "")
        {
            output = "zero";
        }
        Console.WriteLine(output);
    }
}
