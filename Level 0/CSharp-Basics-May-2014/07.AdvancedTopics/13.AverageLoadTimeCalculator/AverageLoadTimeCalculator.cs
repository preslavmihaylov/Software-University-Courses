using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// since the text is too large, I will be declaring it here and not from the console
class AverageLoadTimeCalculator
{
    static void Main()
    {
        string[] input = new string[] 
        {
        "2014-Apr-01 02:01 http://softuni.bg 8.37725",
        "2014-Apr-01 02:05 http://www.nakov.com 11.622",
        "2014-Apr-01 02:06 http://softuni.bg 4.33",
        "2014-Apr-01 02:11 http://www.google.com 1.94",
        "2014-Apr-01 02:11 http://www.google.com 2.011",
        "2014-Apr-01 02:12 http://www.google.com 4.882",
        "2014-Apr-01 02:34 http://softuni.bg 4.885",
        "2014-Apr-01 02:36 http://www.nakov.com 10.74",
        "2014-Apr-01 02:36 http://www.nakov.com 11.75",
        "2014-Apr-01 02:38 http://softuni.bg 3.886",
        "2014-Apr-01 02:44 http://www.google.com 1.04",
        "2014-Apr-01 02:48 http://www.google.com 1.4555",
        "2014-Apr-01 02:55 http://www.google.com 1.977"

        };
        
        // the other data
        //2014-Mar-02 11:33 http://softuni.bg 8.37725
        //2014-Mar-02 11:34 http://www.google.com 1.335
        //2014-Mar-03 21:03 http://softuni.bg 7.25
        //2014-Mar-03 22:00 http://www.google.com 2.44
        //2014-Mar-03 22:01 http://www.google.com 2.45
        //2014-Mar-03 22:01 http://www.google.com 2.77


        Dictionary<string, double[]> data = new Dictionary<string, double[]>();

        foreach (var item in input)
        {
            string currentKey = "";
            // the array of 2 elements is so that the first element contains the sum of all the numbers,
            // while the second element contains the count of the numbers. Thus allowing me to calculate the average load time
            double[] currentDouble = new double[2];

            string[] fragments = item.Split();
            for (int index = 0; index < fragments.Length; index++)
            {
                Match match = Regex.Match(fragments[index], "http.*", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    currentKey = fragments[index];
                }

                if (double.TryParse(fragments[index], out currentDouble[0]))
                {
                    currentDouble[1] = 1;
                }
            }

            if (!data.ContainsKey(currentKey))
            {
               data.Add(currentKey, currentDouble); 
            }
            else
            {
                data[currentKey][0] += currentDouble[0];
                data[currentKey][1] += currentDouble[1];
            }
        }

        foreach (var item in data)
        {
            Console.WriteLine("{0} -> {1}", item.Key, item.Value[0] / item.Value[1]);
        }
    }
}
