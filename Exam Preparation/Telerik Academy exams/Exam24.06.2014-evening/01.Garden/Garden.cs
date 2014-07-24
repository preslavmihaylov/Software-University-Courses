using System;

class Garden
{
    static void Main()
    {
        decimal totalAmount = 0;
        int totalArea = 0;

        for (int index = 0; index < 5; index++)
        {
            int seedsAmount = int.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            totalArea += area;
            switch (index)
            {
                case 0:
                    totalAmount += seedsAmount * 0.5m;
                    break;
                case 1:
                    totalAmount += seedsAmount * 0.4m;
                    break;
                case 2:
                    totalAmount += seedsAmount * 0.25m;
                    break;
                case 3:
                    totalAmount += seedsAmount * 0.6m;
                    break;
                case 4:
                    totalAmount += seedsAmount * 0.3m;
                    break;
            }
        }

        int beansAmount = int.Parse(Console.ReadLine());
        totalAmount += beansAmount * 0.4m;

        Console.WriteLine("Total costs: {0:0.00}", totalAmount);

        if (totalArea < 250)
        {
            Console.WriteLine("Beans area: " + (250 - totalArea));
        }
        else if (totalArea == 250)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Insufficient area");
        }
    }
}
