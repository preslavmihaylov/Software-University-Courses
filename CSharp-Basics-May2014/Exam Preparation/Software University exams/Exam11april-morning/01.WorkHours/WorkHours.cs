using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class WorkHours
{
    static void Main()
    {
        long requiredHours = int.Parse(Console.ReadLine());
        decimal availableDays = decimal.Parse(Console.ReadLine());
        int percentProductivity = int.Parse(Console.ReadLine());

        long result = 0;

        availableDays -= (availableDays * 10) / 100;

        result = (long)(((availableDays * 12) * percentProductivity) / 100) - requiredHours;

        if (result >= 0)
        {
            Console.WriteLine("Yes");
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine(result);
        }
    }
}
