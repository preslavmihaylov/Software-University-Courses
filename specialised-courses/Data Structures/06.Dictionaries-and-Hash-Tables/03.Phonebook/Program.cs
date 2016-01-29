namespace _03.Phonebook
{
    using System;

    class Program
    {
        static void Main()
        {
            HashTable<string, string> hashTable = new HashTable<string, string>();

            string input = Console.ReadLine();

            while (input != "search")
            {
                string[] parameters = input.Split('-');
                string contact = parameters[0];
                string number = parameters[1];

                hashTable[contact] = number;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end")
            {
                if (hashTable.ContainsKey(input))
                {
                    Console.WriteLine("{0} -> {1}", input, hashTable[input]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist", input);
                }

                input = Console.ReadLine();
            }
        }
    }
}