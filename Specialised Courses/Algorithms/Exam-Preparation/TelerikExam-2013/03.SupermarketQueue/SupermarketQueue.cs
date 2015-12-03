using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

class SupermarketQueue
{
    const string EndCommand = "End";
    const string AppendCommand = "Append";
    const string InsertCommand = "Insert";
    const string FindCommand = "Find";
    const string ServeCommand = "Serve";

    static BigList<string> people = new BigList<string>();
    static Dictionary<string, int> names = new Dictionary<string, int>();
    static StringBuilder output = new StringBuilder();

    static void Main()
    {
        ProcessInput();
    }

    static void ProcessInput()
    {
        string command = Console.ReadLine();
        string[] commandParameters;

        while (command != EndCommand)
        {
            commandParameters = command.Split(' ');

            ProcessCommand(commandParameters[0], commandParameters);

            command = Console.ReadLine();
        }

        Console.Write(output.ToString());
    }

    static void ProcessCommand(string command, string[] parameters)
    {
        switch (command)
        {
            case AppendCommand:
                string name = parameters[1];
                Append(name);

                break;
            case FindCommand:
                name = parameters[1];
                Find(name);

                break;
            case InsertCommand:
                int position = int.Parse(parameters[1]);
                name = parameters[2];
                Insert(name, position);

                break;
            case ServeCommand:
                int count = int.Parse(parameters[1]);
                Serve(count);

                break;
            default:
                throw new ArgumentException("Invalid command");
        }
    }

    static void Append(string name)
    {
        people.Add(name);

        if (!names.ContainsKey(name))
        {
            names.Add(name, 0);
        }

        names[name]++;
        output.AppendLine("OK");
    }

    static void Find(string name)
    {
        if (!names.ContainsKey(name))
        {
            output.AppendLine("0");
        }
        else
        {
            output.AppendLine(names[name].ToString());
        }
    }

    static void Insert(string name, int position)
    {
        if (position > people.Count || position < 0)
        {
            output.AppendLine("Error");
            return;
        }

        people.Insert(position, name);

        if (!names.ContainsKey(name))
        {
            names.Add(name, 0);
        }

        ++names[name];
        output.AppendLine("OK");
    }

    static void Serve(int count)
    {
        if (count > people.Count)
        {
            output.AppendLine("Error");
            return;
        }

        for (int index = 0; index < count; index++)
        {
            string name = people[index];
            names[name]--;

            if (names[name] < 0)
            {
                names[name] = 0;
            }

            output.Append(name + " ");
        }

        people.RemoveRange(0, count);
        output.AppendLine();
    }
}