using System;
using System.Diagnostics;
using System.Linq;
using _01.DataFromRelatedTables;

class SelectOptimisation
{
    // Note: I have referenced the AdsEntities from the previous project 
    // instead of creating another one in this project.

    static void Main()
    {
        /*
         * Write a program to compare the execution speed between these two scenarios:
         *      Select everything from the Ads table and print only the ad title.
         *      Select the ad title from Ads table and print it.
         */

        var context = new AdsEntities();
        Stopwatch sw = new Stopwatch();

        sw.Start();
        for (int count = 0; count < 10; count++)
        {
            var ads = context.Ads.Select(a => a);
            
            foreach (var ad in ads)
            {
                Console.WriteLine(ad.Title);
            }
        }

        TimeSpan unoptimisedTime = sw.Elapsed;
        sw.Restart();

        for (int count = 0; count < 10; count++)
        {
            var ads = context.Ads.Select(a => a.Title);

            foreach (var adTitle in ads)
            {
                Console.WriteLine(adTitle);
            }
        }

        TimeSpan optimisedTime = sw.Elapsed;
        sw.Stop();

        /*
         * Unoptimised: 5.5 seconds
         * Optimised: 0.2 seconds
         */

        Console.WriteLine();
        Console.WriteLine("Unoptimised: {0}", unoptimisedTime);
        Console.WriteLine("Optimised: {0}", optimisedTime);
    }
}