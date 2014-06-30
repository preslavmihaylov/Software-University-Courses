using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// note: 12:30 AM is 00:30 and 12:30 PM is 12:30 (lunchtime)... Damn americans and their times...

class BeerTime
{
    static void Main()
    {
        string input = Console.ReadLine();
        DateTime time;

        if (DateTime.TryParse(input, out time))
        {
            if (time.Hour >= 13 || time.Hour < 3)
            {
                Console.WriteLine("beer time");
            }
            else if (time.Hour == 3 && time.Minute == 0)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
        else
        {
            Console.WriteLine("invalid time");
        }
        
    }
}
