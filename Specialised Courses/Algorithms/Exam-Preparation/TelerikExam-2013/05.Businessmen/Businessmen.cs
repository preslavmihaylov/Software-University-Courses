using System;

class Businessmen
{
    static long[] results;

    static void Main()
    {
        ProcessAlgorithm();
    }

    static void ProcessAlgorithm()
    {
        int businessmenCount = ProcessInput();
        Console.WriteLine(CalculateMaxShakes(businessmenCount));
    }

    static long CalculateMaxShakes(int cnt)
    {
        if (cnt <= 0)
        {
            return 1;
        }
        else if (results[cnt] != 0)
        {
            return results[cnt];
        }


        long result = 0;
        int totalShakesPossible = cnt - 2;

        for (int i = 0; i <= totalShakesPossible; i += 2)
        {
            long currentResult = 1;
            currentResult *= CalculateMaxShakes(i);
            currentResult *= CalculateMaxShakes(totalShakesPossible - i);
            result += currentResult;
        }

        results[cnt] = result;
        return result;
    }

    static int ProcessInput()
    {
        int count = int.Parse(Console.ReadLine());
        results = new long[count + 1];
        return count;
    }

}