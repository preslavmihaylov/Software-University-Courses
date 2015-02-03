using System;

class Warhead
{
    static int[,] field = new int[16, 16];
    static void Main()
    {
        for (int row = 0; row < 16; row++)
        {
            string input = Console.ReadLine();
            for (int col = 0; col < 16; col++)
            {
                field[row, col] = Convert.ToInt32(Convert.ToString(input[col]));
            }
        }

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "hover")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                if (field[row,col] == 1)
                {
                    Console.WriteLine("*");
                }
                else
                {
                    Console.WriteLine("-");
                }
            }
            else if (command == "operate")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                bool boom = CheckPosition(row, col);

                if (boom)
                {
                    return;  
                }
            }
            else if (command == "cut")
            {
                string wire = Console.ReadLine();
                int electricCurrentsCountBlue = 0;
                int electricCurrentsCountRed = 0;

                if (wire == "blue")
                {
                    electricCurrentsCountBlue = CountElectricCurrents(9, 15);

                    if (electricCurrentsCountBlue > 0)
                    {
                        Console.WriteLine(electricCurrentsCountBlue);
                        Console.WriteLine("BOOM");
                    }
                    else
                    {
                        electricCurrentsCountRed = CountElectricCurrents(1, 8);
                        Console.WriteLine(electricCurrentsCountRed);
                        Console.WriteLine("disarmed");
                    }
                }
                else
                {
                    electricCurrentsCountRed = CountElectricCurrents(1, 8);

                    if (electricCurrentsCountRed > 0)
                    {
                        Console.WriteLine(electricCurrentsCountRed);
                        Console.WriteLine("BOOM");
                    }
                    else
                    {
                        electricCurrentsCountBlue = CountElectricCurrents(9, 15);
                        Console.WriteLine(electricCurrentsCountBlue);
                        Console.WriteLine("disarmed");
                    }
                }

                return;
            }
        }
    }

    private static bool CheckPosition(int row, int col)
    {
        if (field[row, col] == 1)
        {
            int count = 0;

            count = CountElectricCurrents(1, 15);

            Console.WriteLine("missed");
            Console.WriteLine(count);
            Console.WriteLine("BOOM");
            return true;
        }
        else if (row != 0 && row != 15 && col != 0 && col != 15)
        {
            if (field[row, col - 1] == 1 && field[row, col + 1] == 1 &&                                         // center
                field[row - 1, col - 1] == 1 && field[row - 1, col] == 1 && field[row - 1, col + 1] == 1 &&     // top
                field[row + 1, col - 1] == 1 && field[row + 1, col] == 1 && field[row + 1, col + 1] == 1)       // bot
            {
                field[row, col - 1] = 0;
                field[row, col + 1] = 0;
                field[row - 1, col - 1] = 0;
                field[row - 1, col] = 0; 
                field[row - 1, col + 1] = 0;
                field[row + 1, col - 1] = 0;
                field[row + 1, col] = 0;
                field[row + 1, col + 1] = 0;
            }
        }

        return false;
    }

    static int CountElectricCurrents(int start, int end)
    {
        int count = 0;

        for (int rows = 1; rows < 15; rows++)
        {
            for (int cols = start; cols < end; cols++)
            {
                if (field[rows, cols - 1] == 1 && field[rows, cols + 1] == 1 && field[rows, cols] == 0 &&                   // center
                    field[rows - 1, cols - 1] == 1 && field[rows - 1, cols] == 1 && field[rows - 1, cols + 1] == 1 &&       // top
                    field[rows + 1, cols - 1] == 1 && field[rows + 1, cols] == 1 && field[rows + 1, cols + 1] == 1)         // bot
                {
                    count++;
                }
            }
        }

        return count;
    }
}
