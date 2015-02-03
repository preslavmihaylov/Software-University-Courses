using System;

class InterestCalculatorDemo
{
    static void Main()
    {
        Func<int, double, int, string> CalculateInterest = GetCompoundInterest;

        InterestCalculator interestCalculator = new InterestCalculator(500, 5.6, 10, CalculateInterest);
        Console.WriteLine(interestCalculator.Result);

        interestCalculator.Sum = 2500;
        interestCalculator.Interest = 7.2;
        interestCalculator.Years = 15;
        interestCalculator.CalculateInterestDelegate = GetSimpleInterest;
        Console.WriteLine(interestCalculator.Result);
    }

    private static string GetSimpleInterest(int sum, double interest, int years)
    {
        double result = sum * (1 + (interest / 100) * years);
        return String.Format("{0:0.0000}", result);
    }

    private static string GetCompoundInterest(int sum, double interest, int years)
    {
        double quotient = (1 + (interest / 100) / 12);
        double result = quotient;
        for (int count = 1; count < years * 12; count++)
        {
            result *= quotient;
        }
        result *= sum;
        return String.Format("{0:0.0000}", result);
    }
}
