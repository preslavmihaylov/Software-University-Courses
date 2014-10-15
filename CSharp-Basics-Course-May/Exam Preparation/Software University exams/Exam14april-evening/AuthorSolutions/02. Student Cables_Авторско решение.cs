using System;

class StudentCables
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int totalLength = 0;
        int joins = 0;
        for (int i = 0; i < n; i++)
        {
            int length = int.Parse(Console.ReadLine());
            string measure = Console.ReadLine();
            if (measure == "meters")
            {
                // Convert meters to centimeters
                length = length * 100;
            }
            if (length >= 20)
            {
                totalLength += length;
                joins++;
            }
        }

        // Substract the lost length for joining the cables
        totalLength = totalLength - 3 * (joins - 1);

        int cablesCount = totalLength / 504;
        int remainder = totalLength % 504;

        Console.WriteLine(cablesCount);
        Console.WriteLine(remainder);
    }
}
