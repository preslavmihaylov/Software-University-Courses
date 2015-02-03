using System;

class Electricity
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        DateTime currentTime = DateTime.Parse(Console.ReadLine());

        DateTime afternoonStart = DateTime.Parse("14:00");
        DateTime afternoonEnd = DateTime.Parse("18:59");

        int resultAfternoonStart = DateTime.Compare(currentTime, afternoonStart);
        int resultAfternoonEnd = DateTime.Compare(currentTime, afternoonEnd);

        DateTime eveningStart = DateTime.Parse("19:00");
        DateTime eveningEnd = DateTime.Parse("23:59");

        int resultEveningStart = DateTime.Compare(currentTime, eveningStart);
        int resultEveningEnd = DateTime.Compare(currentTime, eveningEnd);

        DateTime morningStart = DateTime.Parse("00:00");
        DateTime morningEnd = DateTime.Parse("08:59");

        int resultMorningStart = DateTime.Compare(currentTime, morningStart);
        int resultMorningEnd = DateTime.Compare(currentTime, morningEnd);

        decimal result = 0;
        decimal totalFlats = floors * flats;

        // lamps - 100.53; PCs - 125.90
        if (resultAfternoonEnd <= 0 && resultAfternoonStart >= 0)
        {
            result = totalFlats * (2 * 100.53m + 2 * 125.90m);
        }
        else if (resultEveningEnd <= 0 && resultEveningStart >= 0)
        {
            result = totalFlats * (7 * 100.53m + 6 * 125.90m);
        }
        else if (resultMorningEnd <= 0 && resultMorningStart >= 0)
        {
            result = totalFlats * (1 * 100.53m + 8 * 125.90m);
        }

        Console.WriteLine((long)result + " Watts");
    }
}
