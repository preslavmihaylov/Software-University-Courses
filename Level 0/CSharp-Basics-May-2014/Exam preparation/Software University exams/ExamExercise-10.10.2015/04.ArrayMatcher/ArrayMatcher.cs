namespace _04.ArrayMatcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ArrayMatcher
    {
        private static string firstArray;
        private static string secondArray;
        private static List<char> result = new List<char>();

        static void Main()
        {
            string[] input = Console.ReadLine().Split('\\');
            firstArray = input[0];
            secondArray = input[1];
            string command = input[2];


            switch (command)
            {
                case "join":
                    JoinArrays();
                    // result = firstArray.Intersect(secondArray).ToList();
                    break;
                case "left exclude":
                    LeftExclude();
                    // result = secondArray.Where(c => !firstArray.Contains(c)).ToList();
                    break;
                case "right exclude":
                    RightExclude();
                    // result = firstArray.Where(c => !secondArray.Contains(c)).ToList();
                    break;
            }

            result.Sort();
            for (int index = 0; index < result.Count; index++)
            {
                Console.Write(result[index]);   
            }
            Console.WriteLine();
        }

        
        static void JoinArrays()
        {
            for (int firstCharIndex = 0; firstCharIndex < firstArray.Length; firstCharIndex++)
            {
                bool isPresent = false;

                for (int secondCharIndex = 0; secondCharIndex < secondArray.Length; secondCharIndex++)
                {
                    if (firstArray[firstCharIndex] == secondArray[secondCharIndex])
                    {
                        isPresent = true;
                        break;
                    }
                }

                if (isPresent)
                {
                    result.Add(firstArray[firstCharIndex]);
                }
            }
        }

        static void RightExclude()
        {
            for (int firstCharIndex = 0; firstCharIndex < firstArray.Length; firstCharIndex++)
            {
                bool isPresent = false;

                for (int secondCharIndex = 0; secondCharIndex < secondArray.Length; secondCharIndex++)
                {
                    if (firstArray[firstCharIndex] == secondArray[secondCharIndex])
                    {
                        isPresent = true;
                        break;
                    }
                }

                if (!isPresent)
                {
                    result.Add(firstArray[firstCharIndex]);
                }
            }
        }

        static void LeftExclude()
        {
            for (int secondCharIndex = 0; secondCharIndex < secondArray.Length; secondCharIndex++)
            {
                bool isPresent = false;

                for (int firstCharIndex = 0; firstCharIndex < firstArray.Length; firstCharIndex++)
                {
                    if (firstArray[firstCharIndex] == secondArray[secondCharIndex])
                    {
                        isPresent = true;
                        break;
                    }
                }

                if (!isPresent)
                {
                    result.Add(secondArray[secondCharIndex]);
                }
            }
        }
        
    }
}