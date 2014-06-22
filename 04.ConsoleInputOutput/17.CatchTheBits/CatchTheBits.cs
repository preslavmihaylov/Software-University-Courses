using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class CatchTheBits
{
    static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int count = 1;
        string result = "";

        for (int index = 0; index < numberOfInputs; index++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int bit = 7; bit >= 0; bit--)
            {
                if (count == 0)
                {
                    int extractBit = (number >> bit) & 1;
                    result += extractBit;
                    count = step;
                    if (result.Length == 8)
                    {
                        Console.WriteLine(Convert.ToInt32(result, 2));
                        result = "";
                    }
                }
                count--;
            }
        }

        if (result.Length < 8 && result.Length != 0)
        {
            result = Convert.ToString(result).PadRight(8, '0');
            Console.WriteLine(Convert.ToInt32(result, 2));
        }
    }
}
