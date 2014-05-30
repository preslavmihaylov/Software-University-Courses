using System;
using System.Collections.Generic;
class SequenceOfKNums
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        List<int> numbers = new List<int>();
        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < input.Length; i++)
        {
            numbers.Add(int.Parse(input[i]));
        }

        List<int> ToBeRemoved = new List<int>();

        if (k != 1)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                bool matchFound = false;
                int count = 1;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                        if (count == k)
                        {
                            i = j;
                            matchFound = true;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        break;
                    }

                }

                if (matchFound == true)
                {
                    continue;
                }
                Console.Write(numbers[i] + " ");
            }
        }
    }
}