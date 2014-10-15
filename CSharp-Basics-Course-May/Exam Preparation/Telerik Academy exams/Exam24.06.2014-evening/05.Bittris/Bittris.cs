using System;

class Bittris
{
    static void Main()
    {
        long numOfCommands = long.Parse(Console.ReadLine());
        long[] playingField = new long[4];
        long totalScore = 0;

        while (numOfCommands > 0)
        {
            long number = long.Parse(Console.ReadLine());
            long currentScore = 0;
            long countNumber = number;

            while (countNumber > 0)
            {
                long bit = 1 & countNumber;
                if (bit == 1)
                {
                    currentScore++;
                }

                countNumber >>= 1;
            }

            number &= 255;
            // check for endgame
            bool landed = false;

            if (playingField[0] != 0)
            {
                break;
            }
            int position = 0;

            for (long index = 0; index < 3; index++)
            {
                string command = Console.ReadLine();
                long check;

                if (command == "R" && !landed)
                {
                    check = number & 1;
                    if (check != 1)
                    {
                        number >>= 1;
                    }
                }
                else if (command == "L" && !landed)
                {
                    check = (1 << 7) & number;
                    if (check == 0)
                    {
                        number <<= 1;
                    }
                }

                check = number & playingField[index + 1];
                if (check == 0 && !landed)
                {
                    position++;
                }
                else
                {
                    landed = true;
                }
            }

            playingField[position] |= number;
            if (playingField[position] == 255)
            {
                playingField[position] = 0;
                currentScore *= 10;
                for (long currentRow = position; currentRow > 0; currentRow--)
                {
                    playingField[currentRow] = playingField[currentRow - 1];
                    playingField[currentRow - 1] = 0;
                }
            }
            totalScore += currentScore;
            numOfCommands -= 4;
        }

        Console.WriteLine(totalScore);
    }
}
