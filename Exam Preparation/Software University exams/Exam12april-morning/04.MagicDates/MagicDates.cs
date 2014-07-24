using System;

public class House
{
    public static void Main()
    {
        int startYear = int.Parse(Console.ReadLine());
        int endYear = int.Parse(Console.ReadLine());
        int magicWeight = int.Parse(Console.ReadLine());

        bool resultFound = false;

        DateTime currentDate = new DateTime(startYear, 01, 01);
        int currentYear = currentDate.Year;
        int currentResult = 0;
        while (currentYear <= endYear)
        {
            currentResult = getResult(currentDate);

            if (currentResult == magicWeight)
            {
                Console.WriteLine(currentDate.ToString("dd-MM-yyyy"));
                resultFound = true;
            }
            currentDate = currentDate.AddDays(1);
            currentYear = currentDate.Year;
        }

        if (resultFound == false)
        {
            Console.WriteLine("No");
        }
    }

    private static int getResult(DateTime date)
    {
        string temp = date.ToString("ddMMyyyy");
        int result = 0;

        for (int outer = temp.Length - 2; outer >= 0; outer--)
        {
            int currentDigit = Convert.ToInt32(Convert.ToString(temp[outer]));
            if (currentDigit == 0)
	        {
		        continue;
	        }
            for (int inner = outer + 1; inner < temp.Length; inner++)
            {
                int nextDigit = Convert.ToInt32(Convert.ToString(temp[inner]));
                result += currentDigit * nextDigit;
            }
        }

        return result;
    }
}

