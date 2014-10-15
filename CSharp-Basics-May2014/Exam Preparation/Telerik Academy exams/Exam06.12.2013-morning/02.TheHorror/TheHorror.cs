using System;

class TheHorror
{
    static void Main()
    {
        string text = Console.ReadLine();
        long sum = 0;
        int digitsCount = 0;

        for (int index = 0; index < text.Length; index++)
        {
            int number = 0;
            if (int.TryParse(Convert.ToString(text[index]), out number) && index % 2 == 0)
            {
                sum += number;
                digitsCount++;
            }
        }

        Console.WriteLine(digitsCount + " " + sum);
    }
}
