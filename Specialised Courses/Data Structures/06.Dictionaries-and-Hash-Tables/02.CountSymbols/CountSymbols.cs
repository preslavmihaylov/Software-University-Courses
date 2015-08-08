namespace _02.CountSymbols
{
    using System;
    using System.Linq;

    class CountSymbols
    {
        static void Main()
        {
            string text = Console.ReadLine();

            HashTable<char, int> hashTable = new HashTable<char, int>();

            foreach (char ch in text)
            {
                if (!hashTable.ContainsKey(ch))
                {
                    hashTable[ch] = 0;
                }

                hashTable[ch]++;
            }

            KeyValue<char, int>[] arr = hashTable.OrderBy(kv => kv.Key).ToArray();

            foreach (var keyValue in arr)
            {
                Console.WriteLine("{0} : {1} time/s", keyValue.Key, keyValue.Value);
            }
        }
    }
}