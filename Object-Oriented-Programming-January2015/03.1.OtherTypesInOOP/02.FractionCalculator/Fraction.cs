using System;

struct Fraction
{
    private long numerator;
    private long denominator;

    public long Numerator 
    {
        get
        {
            return this.numerator;
        }

        set
        {
            this.numerator = value;
        }
    }

    public long Denominator
    {
        get
        {
            return this.denominator;
        }

        set
        {
            if (value == 0)
            {
                throw new ArgumentException("The value of the denominator cannot be zero.");
            }

            this.denominator = value;
        }
    }

    public Fraction(long numerator, long denominator)
    {
        this.numerator = 1;
        this.denominator = 1;

        this.Numerator = numerator;
        this.Denominator = denominator;
    }

    public static Fraction operator +(Fraction first, Fraction second)
    {
        long commonDenominator = first.Denominator * second.Denominator;
        long commonNumerator = (first.Numerator * (commonDenominator / first.denominator)) + (second.Numerator * (commonDenominator / second.denominator));

        long gcd = findGCD(commonDenominator, commonNumerator);
        return new Fraction(commonNumerator / gcd, commonDenominator / gcd);
    }

    public static Fraction operator -(Fraction first, Fraction second)
    {
        long commonDenominator = first.Denominator * second.Denominator;
        long commonNumerator = (first.Numerator * (commonDenominator / first.denominator)) - (second.Numerator * (commonDenominator / second.denominator));

        long gcd = findGCD(commonDenominator, commonNumerator);
        return new Fraction(commonNumerator / gcd, commonDenominator / gcd);
    }

    private static long findGCD(long first, long second)
    {
        if (second > first)
        {
            long temp = first;
            first = second;
            second = temp;
        }

        long remainder = -1;
        long quotient = 0;

        while (remainder != 0)
        {
            remainder = first % second;
            quotient = first / second;
            first = second;
            second = remainder;
        }

        return first;
    }

    public override string ToString()
    {
        return ((double)this.Numerator / (double)this.Denominator).ToString();
    }
}
