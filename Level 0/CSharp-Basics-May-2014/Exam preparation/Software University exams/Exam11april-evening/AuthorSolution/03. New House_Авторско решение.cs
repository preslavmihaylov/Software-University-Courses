using System;

class NewHouse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i += 2)
        {
            int dashesCount = (n - i) / 2;
            string dashes = new string('-', dashesCount);
            string asterisks = new string('*', i);
            Console.Write(dashes);
            Console.Write(asterisks);
            Console.Write(dashes);
            Console.WriteLine();
        }
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("{0}{1}{0}", "|", new string('*', n - 2));
        }
    }
}
