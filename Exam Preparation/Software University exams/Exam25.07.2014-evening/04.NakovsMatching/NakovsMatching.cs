using System;

class NakovsMatching
{
    static void Main()
    {
        // aLeft * bRight - aRight * bLeft

        string firstWord = Console.ReadLine();
        string secondWord = Console.ReadLine();
        long maxMatch = long.Parse(Console.ReadLine());
        bool matchFound = false;

        int[] firstArray = new int[firstWord.Length];
        int[] secondArray = new int[secondWord.Length];

        for (int index = 0; index < firstWord.Length; index++)
        {
            firstArray[index] = firstWord[index];
        }

        for (int index = 0; index < secondWord.Length; index++)
        {
            secondArray[index] = secondWord[index];
        }

        for (int firstBorder = 1; firstBorder < firstArray.Length; firstBorder++)
        {
            for (int secondBorder = 1; secondBorder < secondArray.Length; secondBorder++)
            {
                long aLeft = 0;

                for (int index = 0; index < firstBorder; index++)
                {
                    aLeft += firstArray[index];
                }

                long bLeft = 0;

                for (int index = 0; index < secondBorder; index++)
                {
                    bLeft += secondArray[index];
                }

                long aRight = 0;

                for (int index = firstBorder; index < firstArray.Length; index++)
                {
                    aRight += firstArray[index];
                }

                long bRight = 0;

                for (int index = secondBorder; index < secondArray.Length; index++)
                {
                    bRight += secondArray[index];
                }

                long nakovMatching = Math.Abs(aLeft * bRight - aRight * bLeft);

                if (nakovMatching <= maxMatch)
                {
                    matchFound = true;
                    string aLeftStr = "";

                    for (int index = 0; index < firstBorder; index++)
                    {
                        aLeftStr += (char)firstArray[index];
                    }

                    string bLeftStr = "";

                    for (int index = 0; index < secondBorder; index++)
                    {
                        bLeftStr += (char)secondArray[index];
                    }

                    string aRightStr = "";

                    for (int index = firstBorder; index < firstArray.Length; index++)
                    {
                        aRightStr += (char)firstArray[index];
                    }

                    string bRightStr = "";

                    for (int index = secondBorder; index < secondArray.Length; index++)
                    {
                        bRightStr += (char)secondArray[index];
                    }

                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs",
                        aLeftStr, aRightStr, bLeftStr, bRightStr, nakovMatching);
                }
            }
        }

        if (!matchFound)
        {
            Console.WriteLine("No");
        }
    }
}
