using System;

class EnterNumbers
{
    static void Main()
    {
        int start = 2;
        int end = 100;
        for (int index = 0; index < 10; index++)
        {
            start = readNumber(start, end);
        }
    }

    public static int readNumber(int start, int end)
    {
        try
        {
            int number = -1;
            Console.WriteLine("Enter a number in the range [" + start + ".." + end + "]");

            do
            {
                number = int.Parse(Console.ReadLine());

                if (number < start || start > end)
                {
                    Console.WriteLine("Number is out of range.");
                }
            } while (!(number > start && number < end));

            return number;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
