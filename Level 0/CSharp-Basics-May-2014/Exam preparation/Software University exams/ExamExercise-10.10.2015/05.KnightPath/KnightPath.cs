namespace KnightPath
{
    using System;

    public class KnightPath
    {
        private const int FieldSize = 8;

        private static int[] numbers = new int[FieldSize];
        private static int horseRow = 0;
        private static int horseCol = FieldSize - 1;

        static void Main()
        {
            InstantiateInitialData();
            ProcessInput();
            PrintResult();
        }

        static void InstantiateInitialData()
        {
            ChangePosition(0, FieldSize - 1);
        }

        static void ProcessInput()
        {
            string command = Console.ReadLine();

            while (command != "stop")
            {
                ProcessCommand(command);

                command = Console.ReadLine();
            }
        }

        static void ProcessCommand(string command)
        {
            int velocityRow = 0;
            int velocityCol = 0;

            switch (command)
            {
                case "left up":
                    velocityRow = -1;
                    velocityCol = -2;
                    break;
                case "left down":
                    velocityRow = 1;
                    velocityCol = -2;
                    break;
                case "right up":
                    velocityRow = -1;
                    velocityCol = 2;
                    break;
                case "right down":
                    velocityRow = 1;
                    velocityCol = 2;
                    break;
                case "down left":
                    velocityRow = 2;
                    velocityCol = -1;
                    break;
                case "down right":
                    velocityRow = 2;
                    velocityCol = 1;
                    break;
                case "up left":
                    velocityRow = -2;
                    velocityCol = -1;
                    break;
                case "up right":
                    velocityRow = -2;
                    velocityCol = 1;
                    break;
                default:
                    return;
            }

            ChangeGameState(velocityRow, velocityCol);
        }

        static void ChangeGameState(int velocityRow, int velocityCol)
        {
            int newPositionRow = horseRow + velocityRow;
            int newPositionCol = horseCol + velocityCol;

            if (newPositionRow >= 0 && 
                newPositionRow < FieldSize &&
                newPositionCol >= 0 && newPositionCol < FieldSize)
            {
                horseRow = newPositionRow;
                horseCol = newPositionCol;

                ChangePosition(horseRow, horseCol);   
            }
        }

        static void ChangePosition(int numberIndex, int position)
        {
            position = 7 - position;
            int mask = (1 << position);
            numbers[numberIndex] ^= mask;
        }

        static void PrintResult()
        {
            bool isBoardEmpty = true;

            for (int index = 0; index < FieldSize; index++)
            {
                int number = numbers[index];
                if (number != 0)
                {
                    isBoardEmpty = false;
                    Console.WriteLine(number);
                }
            }

            if (isBoardEmpty)
            {
                Console.WriteLine("[Board is empty]");
            }
        }
    }
}