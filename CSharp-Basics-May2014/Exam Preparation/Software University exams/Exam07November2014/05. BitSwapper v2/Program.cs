using System;

class HalfByteSwapper
{
    static void Main()
    {
        //array for storing the 4 numbers to process
        uint[] numbers = new uint[4];
        for (int count = 0; count < 4; count++)
        {
            numbers[count] = uint.Parse(Console.ReadLine());
        }
        //loop for the commands
        while (true)
        {
            //parse the first command
            string input1 = Console.ReadLine();
            //end of the loop
            if (input1 == "End")
            {
                break;
            }
            //parse the second command
            string input2 = Console.ReadLine();
            //split the commands to two arrays with the method
            int[] command1 = SplitString(input1);
            int[] command2 = SplitString(input2);
            //indexes in the array of the first and second number to be processed
            int num1 = command1[0];
            int num2 = command2[0];
            //bit groups to swap from the first and second number
            int bitGroup1 = command1[1];
            int bitGroup2 = command2[1];

            //store the bits that will be swapped from the first number
            uint bitSwap1 = (numbers[num1] & (15U << 4 * bitGroup1)) >> (bitGroup1 * 4);
            //replace the bits to be swapped with 0000
            numbers[num1] &= ~(15U << 4 * bitGroup1);

            //store the bits that will be swapped from the second number
            uint bitSwap2 = (numbers[num2] & (15U << 4 * bitGroup2)) >> (bitGroup2 * 4);
            //replace the bits to be swapped with 0000
            numbers[num2] &= ~(15U << 4 * bitGroup2);

            //swap the bits!
            numbers[num1] |= bitSwap2 << (4 * bitGroup1);
            numbers[num2] |= bitSwap1 << (4 * bitGroup2);
        }
        //display the result
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
    //method for splitting each command to integers
    public static int[] SplitString(string input)
    {
        string[] strings = input.Split(' ');
        int[] numbers = new int[strings.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(strings[i]);
        }
        return numbers;
    }
}