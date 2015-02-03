using System;
class BitsUp
{
    static void Main()
    {
        int countOfNums = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int count = 0;
        for (int numCount = 0; numCount < countOfNums; numCount++)
        {
            int number = int.Parse(Console.ReadLine());

            for (int bit = 7; bit >= 0; bit--)
            {
                string temp = Convert.ToString(number, 2);
                if (numCount == 0 && bit == 6)
                {
                    number |= (1 << bit);
                    count = 1;
                    continue;
                }
                if (count == step)
                {
                    number |= (1 << bit);
                    count = 1;
                    continue;
                }
                count++;
            }
            Console.WriteLine(number);
        }
    }
}
