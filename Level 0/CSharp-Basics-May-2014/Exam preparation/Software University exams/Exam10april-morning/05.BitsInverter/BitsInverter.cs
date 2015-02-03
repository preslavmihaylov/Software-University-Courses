using System;
using System.Collections.Generic;
using System.Linq;
using System;

class BitsInverter
{
    static void Main()
    {
        // intial input
        int N = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        // this variable will be used to count the bits via the step variable. 
        // Since the count begins from the first bit (from left to right), its initial value is 1.
        int count = 1;
        for (int i = 0; i < N; i++)
        {
            // for each number N of inputs, there will be a different loop to check and count the bits.
            // Note that the variable count doesn't reset with every new input.
            int number = int.Parse(Console.ReadLine());
            for (int bit = 7; bit >= 0; bit--)
            {
                if (count == 1)
                {
                    // the XOR (^) operator is used to swap each bit. Note that (1 ^ 1 = 0) and (0 ^ 1 = 1).
                    number ^= 1 << bit;

                    // this is just a check that has nothing to do with the task. 
                    // I'm just using it to check the progress of the program during debugging. You can try this out as well!
                    string temp = Convert.ToString(number, 2).PadLeft(8, '0');
                    count = step;
                    continue;
                }
                count--;
            }
            // print the final value of the number
            Console.WriteLine(number);
        }
    }
}
