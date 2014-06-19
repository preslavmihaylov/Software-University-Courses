using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class BitsUp
{
    static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int count = 1;

        for (int index = 0; index < numberOfInputs; index++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int bit = 7; bit >= 0; bit--)
            {
                if (count != 0)
                {
                    count--;
                }
                else
                {
                    number |= 1 << bit;
                    count = step - 1;
                }
            }

            Console.WriteLine(number);
        }
    }
}
