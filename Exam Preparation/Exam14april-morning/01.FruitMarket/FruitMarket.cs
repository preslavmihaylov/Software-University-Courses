using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FruitMarket
{
    static double[] vegetables = new double[2];
    static double[] fruit = new double[3];

    static void Main()
    {
        string dayOfWeek = Console.ReadLine();

        double quant1 = double.Parse(Console.ReadLine());
        string prod1 = Console.ReadLine();

        double quant2 = double.Parse(Console.ReadLine());
        string prod2 = Console.ReadLine();

        double quant3 = double.Parse(Console.ReadLine());
        string prod3 = Console.ReadLine();

        GetProduct(prod1, quant1);
        GetProduct(prod2, quant2);
        GetProduct(prod3, quant3);

        switch (dayOfWeek)
        {
            case "Friday":
                for (int index = 0; index < vegetables.Length; index++)
                {
                    vegetables[index] -= (vegetables[index] * 10) / 100;
                }

                for (int index = 0; index < fruit.Length; index++)
                {
                    fruit[index] -= (fruit[index] * 10) / 100;
                }
                break;
            case "Sunday":
                for (int index = 0; index < vegetables.Length; index++)
                {
                    vegetables[index] -= (vegetables[index] * 5) / 100;
                }

                for (int index = 0; index < fruit.Length; index++)
                {
                    fruit[index] -= (fruit[index] * 5) / 100;
                }
                break;
            case "Tuesday":
                for (int index = 0; index < fruit.Length; index++)
                {
                    fruit[index] -= (fruit[index] * 20) / 100;
                }
                break;
            case "Wednesday":
                for (int index = 0; index < vegetables.Length; index++)
                {
                    vegetables[index] -= (vegetables[index] * 10) / 100;
                }
                break;
            case "Thursday":
                fruit[0] -= (fruit[0] * 30) / 100;
                break;
        }

        Console.WriteLine("{0:0.00}", vegetables.Sum() + fruit.Sum());
        
    }

    private static void GetProduct(string prod, double quant)
    {
        switch (prod)
        {
            case "cucumber":
                vegetables[0] += 2.75 * quant;
                break;
            case "tomato":
                vegetables[1] += 3.20 * quant;
                break;
            case "banana":
                fruit[0] += 1.80 * quant;
                break;
            case "orange":
                fruit[1] += 1.60 * quant;
                break;
            case "apple":
                fruit[2] += 0.86 * quant;
                break;
            default:
                break;
        }
    }
}
