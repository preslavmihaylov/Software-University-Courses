using System;
class CatchTheBits
{
    static void Main()
    {
        int numOfInputs = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int count = 1;
        string catchedBits = "";
        
        for (int inputCount = 0; inputCount < numOfInputs; inputCount++)
        {
            int input = int.Parse(Console.ReadLine());
        
            for (int bit = 7; bit >= 0; bit--)
            {
                if (count == 0)
                {
                    string binary = Convert.ToString(input, 2).PadLeft(8, '0');
                    int caughtBit = (input >> bit) & 1;
                    catchedBits += Convert.ToString(caughtBit);
                    count = step;
                }
                if (catchedBits.Length == 8)
                {
                    Console.WriteLine(Convert.ToInt32(catchedBits, 2));
                    catchedBits = "";
                }
                count--;
            }
        }
        
        if (catchedBits.Length < 8 && catchedBits.Length > 0)
        {
            while (catchedBits.Length < 8)
            {
                catchedBits += "0";
            }
            Console.WriteLine(Convert.ToInt32(catchedBits, 2));
        }
    }
}
