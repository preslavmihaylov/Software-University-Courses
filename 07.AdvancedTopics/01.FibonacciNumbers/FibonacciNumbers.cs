using System;

class FibonacciNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        Fib(number);
    }

    private static void Fib(int number)
    {
        int firstNum = 1;
        int secondNum = 1;
        if (number < 2 && number >= 0)
        {
            Console.WriteLine(1);
            return;
        }
        else if (number < 0)
        {
            Console.WriteLine("not a fibonacci number");
            return;
        }

        for (int count = 2; count <= number; count++)
        {
            int temp = secondNum + firstNum;
            firstNum = secondNum;
            secondNum = temp;
        }

        Console.WriteLine(secondNum);
    }
}
