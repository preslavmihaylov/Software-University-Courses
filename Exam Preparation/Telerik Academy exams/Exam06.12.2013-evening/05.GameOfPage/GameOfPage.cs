using System;

class GameOfPage
{
    static int[,] matrix = new int[16, 16];
    static double result = 0;

    static void Main()
    {
        for (int row = 0; row < 16; row++)
        {
            string line = Console.ReadLine();
            
            for (int col = 0; col < 16; col++)
            {
                matrix[row, col] = Convert.ToInt32(Convert.ToString(line[col]));
            }
        }

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "paypal")
            {
                break;
            }
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            string output = CheckPosition(row, col, input);
            if (output.Length > 0)
            {
                Console.WriteLine(output);
            }
        }

        Console.WriteLine("{0:0.00}", result);


    }

    static string CheckPosition (int row, int col, string input)
    {
        int[,] currentSelection = new int[3, 3];
        int currentRow = 0;
        int currentCol = 0;

        for (int matRow = row - 1; matRow <= row + 1; matRow++)
        {
            for (int matCol = col - 1; matCol <= col + 1; matCol++)
            {
                if (matRow >= 0 && matRow <= 15 && matCol >= 0 && matCol <= 15)
                {
                    currentSelection[currentRow, currentCol] = matrix[matRow, matCol];
                }
                else
                {
                    currentSelection[currentRow, currentCol] = 0;
                }
                currentCol++;
            }
            currentRow++;
            currentCol = 0;
        }

        int count = 0;
        for (int matRow = 0; matRow < 3; matRow++)
        {
            for (int matCol = 0; matCol < 3; matCol++)
            {
                if (currentSelection[matRow, matCol] == 1)
                {
                    count++;
                }
            }
        }

        if (input == "what is")
        {
            if (count == 9)
            {
                return "cookie";
            }
            else if (count == 1 && currentSelection[1, 1] == 1)
            {
                return "cookie crumb";
            }
            else if (count > 0 && currentSelection[1, 1] == 1)
            {
                return "broken cookie";
            }
            else
            {
                return "smile";
            }
            
        }
        else
        {
            if (count == 9)
            {
                for (int matRow = row - 1; matRow <= row + 1; matRow++)
                {
                    for (int matCol = col - 1; matCol <= col + 1; matCol++)
                    {
                        matrix[matRow, matCol] = 0;
                    }
                }
                result += 1.79;
                return "";
            }
            else if (count == 0)
            {
                return "smile";
            }
            else
            {
                return "page";
            }
        }
    }
}
