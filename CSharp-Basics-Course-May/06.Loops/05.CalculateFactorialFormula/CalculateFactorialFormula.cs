using System;

class CalculateFactorialFormula
{
    static void Main()
    {
        int factorialNum = int.Parse(Console.ReadLine());
        int multiplicationNum = int.Parse(Console.ReadLine());

        int factorial = 1;
        double sum = 1;
        int multiplication = 1;

        for (int count = 1; count <= factorialNum; count++)
        {
            factorial *= count;
            multiplication *= multiplicationNum;
            sum += (double)factorial / multiplication;
        }
        Console.WriteLine("{0:0.00000}", sum);
    }
}
