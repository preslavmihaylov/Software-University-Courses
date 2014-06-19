using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Volleyball
{
    static void Main()
    {
        string yearType = Console.ReadLine();
        int numberOfHolidays = int.Parse(Console.ReadLine());
        int hometownWeekends = int.Parse(Console.ReadLine());

        double result = 0;

        result += hometownWeekends;

        int normalWeekends = 48 - hometownWeekends;

        result += (double)(normalWeekends * 3) / 4;
        result += (double)(numberOfHolidays * 2) / 3;

        if (yearType == "leap")
        {
            result += (double)(15 * result) / 100;
        }

        Console.WriteLine((int)result);
    }
}
