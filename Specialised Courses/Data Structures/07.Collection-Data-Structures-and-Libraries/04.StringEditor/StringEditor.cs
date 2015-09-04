namespace _04.StringEditor
{
    using System;
    using Wintellect.PowerCollections;

    class StringEditor
    {
        static BigList<char> editor = new BigList<char>();

        static void Main()
        {
            ReadInput();
        }

        private static void ReadInput()
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                ParseCommand(command);

                command = Console.ReadLine();
            }
        }

        private static void ParseCommand(string command)
        {
            string[] commandParameters = command.Split(' ');

            try
            {
                switch (commandParameters[0])
                {
                    case "APPEND":
                        string stringToAppend = commandParameters[1];
                        AppendString(stringToAppend);

                        break;
                    case "INSERT":
                        string stringToInsert = commandParameters[1];
                        int position = int.Parse(commandParameters[2]);
                        InsertString(stringToInsert, position);

                        break;
                    case "DELETE":
                        int startIndex = int.Parse(commandParameters[1]);
                        int count = int.Parse(commandParameters[2]);
                        DeleteString(startIndex, count);

                        break;
                    case "REPLACE":
                        startIndex = int.Parse(commandParameters[1]);
                        count = int.Parse(commandParameters[2]);
                        string stringToReplace = commandParameters[3];
                        ReplaceString(startIndex, count, stringToReplace);

                        break;
                    case "PRINT":
                        PrintCurrentState();

                        break;
                    default:
                        Console.WriteLine("Error: Invalid command");
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AppendString(string stringToAppend)
        {
            foreach (var ch in stringToAppend)
            {
                editor.Add(ch);
            }
        }

        private static void InsertString(string stringToInsert, int position)
        {
            if (position < 0 || position >= editor.Count)
            {
                throw new InvalidOperationException("The specified index is out of range");
            }

            for (int index = stringToInsert.Length - 1; index >= 0; index--)
            {
                editor.Insert(position, stringToInsert[index]);
            }
        }

        private static void DeleteString(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count >= editor.Count || count < 0)
            {
                throw new InvalidOperationException("The specified index range is out of bounds");
            }

            editor.RemoveRange(startIndex, count);
        }

        private static void ReplaceString(int startIndex, int count, string stringToReplace)
        {
            if (startIndex < 0 || startIndex + count >= editor.Count || count < 0)
            {
                throw new InvalidOperationException("The specified index range is out of bounds");
            }

            for (int i = 0; i < count; i++)
            {
                editor.RemoveAt(startIndex);
            }

            for (int index = stringToReplace.Length - 1; index >= 0; index--)
            {
                editor.Insert(startIndex, stringToReplace[index]);
            }
        }

        private static void PrintCurrentState()
        {
            Console.WriteLine(string.Join("", editor));
        }
    }
}