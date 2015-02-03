using System;
using System.Collections.Generic;
class CrossingSequences
{
    static void Main()
    {
        int firstTribElement = int.Parse(Console.ReadLine());
        int secondTribElement = int.Parse(Console.ReadLine());
        int thirdTribElement = int.Parse(Console.ReadLine());

        int spiralNum = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int additionalStep = step;
        bool resultFound = false;

        List<int> tribonacci = new List<int>() { firstTribElement, secondTribElement, thirdTribElement };

        while (true)
        {
            int temp = thirdTribElement;
            thirdTribElement += firstTribElement + secondTribElement;
            firstTribElement = secondTribElement;
            secondTribElement = temp;

            if (thirdTribElement > 1000000)
            {
                break;
            }
            tribonacci.Add(thirdTribElement);
        }

        int count = 0;
        while (spiralNum < 1000000)
        {
            spiralNum += additionalStep;
            count++;

            if (count == 2)
            {
                count = 0;
                additionalStep += step;
            }

            if (tribonacci.Contains(spiralNum))
            {
                resultFound = true;
                Console.WriteLine(spiralNum);
                break;
            }

        }
        if (resultFound == false)
        {
            Console.WriteLine("No");
        }
    }
}