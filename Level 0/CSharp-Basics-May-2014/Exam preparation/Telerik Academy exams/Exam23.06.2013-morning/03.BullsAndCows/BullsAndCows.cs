using System;

class BullsAndCows
{
    static int[] secretNum = new int[4];
    static int[] guessNum = new int[4];

    static void Main()
    {
        string input = Console.ReadLine();
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());
        bool resultFound = false;

        for (int num1 = 1; num1 < 10; num1++)
        {
            for (int num2 = 1; num2 < 10; num2++)
            {
                for (int num3 = 1; num3 < 10; num3++)
                {
                    for (int num4 = 1; num4 < 10; num4++)
                    {
                        guessNum[0] = num1;
                        guessNum[1] = num2;
                        guessNum[2] = num3;
                        guessNum[3] = num4;

                        for (int index = 0; index < secretNum.Length; index++)
                        {
                            secretNum[index] = Convert.ToInt32(Convert.ToString(input[index]));
                        }

                        int bullsCount = CheckForBulls();
                        int cowsCount = CheckForCows();

                        if (bulls == bullsCount && cows == cowsCount)
                        {
                            Console.Write("" + num1 + num2 + num3 + num4 + " ");
                            resultFound = true;
                        }
                    }
                }
            }
        }

        if (!resultFound)
        {
            Console.WriteLine("No");
        }
    }

    private static int CheckForCows()
    {
        int cowsCount = 0;

        for (int secretIndex = 0; secretIndex < 4; secretIndex++)
        {
            for (int guessIndex = 0; guessIndex < 4; guessIndex++)
            {
                if (secretNum[secretIndex] == guessNum[guessIndex] && secretNum[secretIndex] != 0 && guessNum[guessIndex] != 0)
                {
                    cowsCount++;
                    guessNum[guessIndex] = 0;
                    secretNum[secretIndex] = 0;
                }
            }
        }

        return cowsCount;
    }

    private static int CheckForBulls()
    {
        int bullsCount = 0;
        if (guessNum[0] == secretNum[0] && guessNum[0] != 0 && secretNum[0] != 0)
        {
            bullsCount++;
            guessNum[0] = 0;
            secretNum[0] = 0;
        }

        if (guessNum[1] == secretNum[1] && guessNum[1] != 0 && secretNum[1] != 0)
        {
            bullsCount++;
            guessNum[1] = 0;
            secretNum[1] = 0;
        }

        if (guessNum[2] == secretNum[2] && guessNum[2] != 0 && secretNum[2] != 0)
        {
            bullsCount++;
            guessNum[2] = 0;
            secretNum[2] = 0;
        }

        if (guessNum[3] == secretNum[3] && guessNum[3] != 0 && secretNum[3] != 0)
        {
            bullsCount++;
            guessNum[3] = 0;
            secretNum[3] = 0;
        }

        return bullsCount;
    }
}