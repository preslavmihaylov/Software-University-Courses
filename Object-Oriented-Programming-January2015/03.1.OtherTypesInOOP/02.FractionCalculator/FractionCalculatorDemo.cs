using System;

class FractionCalculatorDemo
{
    static void Main()
    {
        Fraction temp = new Fraction(1, 1);
        temp = temp + new Fraction(5, 2);
        temp = temp - new Fraction(8, 2);
        Console.WriteLine(temp);
    }
}
