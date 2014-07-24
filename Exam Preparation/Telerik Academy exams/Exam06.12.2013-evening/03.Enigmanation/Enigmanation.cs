using System;
using System.Data;

class Enigmanation
{
    static void Main()
    {
        char symbol = Convert.ToChar(Console.Read());
        decimal sum = 0;
        char calc = '+';

        while (symbol != '=')
        {
            int number = 0;
            if (int.TryParse(Convert.ToString(symbol), out number))
            {
                switch (calc)
                {
                    case '+':
                        sum += number;
                        break;
                    case '%':
                        sum %= number;
                        break;
                    case '*':
                        sum *= number;
                        break;
                    default:
                        sum -= number;
                        break;
                }
            }
            else if (symbol == '(')
            {
                decimal innerSum = 0;
                char innerCalc = '+';

                while (symbol != ')')
                {
                    symbol = Convert.ToChar(Console.Read());

                    if (int.TryParse(Convert.ToString(symbol), out number))
                    {
                        switch (innerCalc)
                        {
                            case '+':
                                innerSum += number;
                                break;
                            case '%':
                                innerSum %= number;
                                break;
                            case '*':
                                innerSum *= number;
                                break;
                            default:
                                innerSum -= number;
                                break;
                        }
                    }
                    else
                    {
                        switch (symbol)
                        {
                            case '+':
                                innerCalc = '+';
                                break;
                            case '%':
                                innerCalc = '%';
                                break;
                            case '*':
                                innerCalc = '*';
                                break;
                            default:
                                innerCalc = '-';
                                break;
                        }
                    }
                }

                switch (calc)
                {
                    case '+':
                        sum += innerSum;
                        break;
                    case '%':
                        sum %= innerSum;
                        break;
                    case '*':
                        sum *= innerSum;
                        break;
                    default:
                        sum -= innerSum;
                        break;
                }
            }
            else
            {
                switch (symbol)
                {
                    case '+':
                        calc = '+';
                        break;
                    case '%':
                        calc = '%';
                        break;
                    case '*':
                        calc = '*';
                        break;
                    default:
                        calc = '-';
                        break;
                }
            }

            symbol = Convert.ToChar(Console.Read());
        }

        Console.WriteLine("{0:0.000}", sum);
    }
}
