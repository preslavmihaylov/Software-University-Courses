using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class FormattingNumbers
{
    static void Main()
    {
        Console.WriteLine("Input number 1:");
        int number1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Input number 2:");
        double number2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Input number 3:");
        double number3 = double.Parse(Console.ReadLine());

        Console.Write("|{0, -10:X}|{1}|{2, 10:F2}|", number1, Convert.ToString(number1, 2).PadLeft(10, '0'),
            number2);

        int check;
        if (int.TryParse(Convert.ToString(number3), out check))
        {
            Console.WriteLine("{0, -10:0}|", number3);
        }
        else
        {
            Console.WriteLine("{0, -10:0.000}|", number3);
        }
    }
}
