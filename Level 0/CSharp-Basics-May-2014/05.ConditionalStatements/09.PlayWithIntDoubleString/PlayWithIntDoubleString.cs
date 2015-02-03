using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayWithIntDoubleString
{
    static void Main()
    {
        Console.WriteLine(@"
Please choose a type:
1 --> int
2 --> double
3 --> string
");
        int input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case 1:
                Console.WriteLine("Please enter an integer:");
                int intNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Result: {0}", intNum + 1);
                break;
            case 2:
                Console.WriteLine("Please enter a double:");
                double doubleNum = double.Parse(Console.ReadLine());
                Console.WriteLine("Result: {0}", doubleNum + 1);
                break;
            default:
                Console.WriteLine("Please enter a string:");
                string stringInput = Console.ReadLine();
                Console.WriteLine("Result: {0}", stringInput + "*");
                break;
        }
    }
}
