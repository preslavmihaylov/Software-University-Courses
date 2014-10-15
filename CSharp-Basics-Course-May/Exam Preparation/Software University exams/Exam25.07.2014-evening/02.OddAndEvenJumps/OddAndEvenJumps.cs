using System;

class OddAndEvenJumps
{
    static void Main()
    {
        string text = Console.ReadLine();
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());

        string oddText = "";
        string evenText = "";
        text = text.ToLower();
        text = text.Replace(" ", "");

        for (int index = 0; index < text.Length; index++)
        {
            if ((index + 1) % 2 == 1)
            {
                oddText += Convert.ToString(text[index]);
            }
            else
            {
                evenText += Convert.ToString(text[index]);
            }
        }

        long oddResult = 0;
        long evenResult = 0;
        int count = 1;

        for (int index = 0; index < oddText.Length; index++)
        {
            if (count != oddJump)
            {
                oddResult += oddText[index];
                count++;
            }
            else
            {
                oddResult *= oddText[index];
                count = 1;
            }
        }

        count = 1;
        for (int index = 0; index < evenText.Length; index++)
        {
            if (count != evenJump)
            {
                evenResult += evenText[index];
                count++;
            }
            else
            {
                evenResult *= evenText[index];
                count = 1;
            }
        }

        Console.WriteLine("Odd: " + Convert.ToString(oddResult, 16).ToUpper());
        Console.WriteLine("Even: " + Convert.ToString(evenResult, 16).ToUpper());
    }
}
