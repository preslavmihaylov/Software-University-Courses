using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
class ExamSchedule
{
    static void Main()
    {
        string input = Console.ReadLine();
        input += ":" + Console.ReadLine();
        input += " " + Console.ReadLine();

        DateTime startingTime = Convert.ToDateTime(input);
        string input2 = Console.ReadLine();
        input2 += ":" + Console.ReadLine();
        DateTime additionalTime = Convert.ToDateTime(input2);
        DateTime resultHours = startingTime.AddHours(additionalTime.Hour);
        DateTime result = resultHours.AddMinutes(additionalTime.Minute);

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

        string output = result.ToString("hh:mm:tt");
        Console.WriteLine(output);
        
    }
}
