namespace _01.WordsInFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class WordsInFile
    {
        private const string FilePath = "../../example.txt";

        static void Main()
        {
            StreamReader reader = new StreamReader(FilePath);
            Dictionary<string, int> wordOccurences = new Dictionary<string,int>();

            string currentLine = reader.ReadLine();

            while (currentLine != null)
            {
                string[] words = currentLine.Split(' ');
                foreach (var word in words)
                {
                    if (!wordOccurences.ContainsKey(word))
                    {
                        wordOccurences[word] = 0;
                    }

                    wordOccurences[word]++;
                }

                currentLine = reader.ReadLine();
            }

            foreach (var wordOccurence in wordOccurences)
            {
                Console.WriteLine("{0} --> {1}", wordOccurence.Key, wordOccurence.Value);
            }
        }
    }
}