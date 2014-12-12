using System;
class HalfByteSwapper
{
    static void Main()
    {
        long[] numbers = new long[4];
        for (int index = 0; index < 4; index++)
        {
            numbers[index] = long.Parse(Console.ReadLine());
        }

        string firstCommand = "";
        string secondCommand = "";

        while (true)
        {
            firstCommand = Console.ReadLine();
            if (firstCommand == "End")
            {
                break;
            }

            secondCommand = Console.ReadLine();

            string[] firstSet = new string[2];
            string[] secondSet = new string[2];

            firstSet = firstCommand.Split(' ');
            secondSet = secondCommand.Split(' ');


            int firstPosition = int.Parse(firstSet[1]);
            int secondPosition = int.Parse(secondSet[1]);

            long firstByte = (numbers[int.Parse(firstSet[0])] >> (4 * firstPosition)) & 15;
            long secondByte = (numbers[int.Parse(secondSet[0])] >> (4 * secondPosition)) & 15;

            // Console.WriteLine(Convert.ToString(secondByte, 2).PadLeft(32, '0'));

            numbers[int.Parse(firstSet[0])] &= ~((long)15 << (firstPosition * 4));
            numbers[int.Parse(secondSet[0])] &= ~((long)15 << (secondPosition * 4));

            numbers[int.Parse(firstSet[0])] |= secondByte << (firstPosition * 4);
            numbers[int.Parse(secondSet[0])] |= firstByte << (secondPosition * 4);
        }

        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
        
    }
}
