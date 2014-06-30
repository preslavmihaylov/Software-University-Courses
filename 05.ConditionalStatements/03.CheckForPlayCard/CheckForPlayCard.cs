using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CheckForPlayCard
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = 0;

        if (int.TryParse(input, out number))
        {
            if (number >= 2 && number <= 10)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        else if (input == "J" || input == "Q" || input == "K" || input == "A")
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
