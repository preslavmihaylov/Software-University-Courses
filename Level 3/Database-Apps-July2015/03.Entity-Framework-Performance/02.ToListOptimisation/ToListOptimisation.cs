using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using _01.DataFromRelatedTables;

class ToListOptimisation
{
    // Note: I have referenced the AdsEntities from the previous project 
    // instead of creating another one in this project.

    static void Main()
    {
        /*
         * Using Entity Framework select all ads from the database, 
         * then invoke ToList(), then filter the categories whose status is Published;
         * then select the ad title, category and town, then invoke ToList() 
         * again and finally order the ads by publish date. 
         * Rewrite the same query in a more optimized way and compare the performance.
         */

        var context = new AdsEntities();

        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int count = 0; count < 10; count++)
        {
            var ads = context.Ads
            .Select(a => a)
            .ToList()
            .Where(a => a.AdStatus != null && a.AdStatus.Status == "Published")
            .Select(a => new
            {
                Title = a.Title,
                Category = a.Category != null ? a.Category.Name : "(null)",
                Town = a.Town != null ? a.Town.Name : "(null)",
                PublishDate = a.Date
            })
            .ToList()
            .OrderBy(a => a.PublishDate);
        }

        // Unoptimised: 5 seconds
        Console.WriteLine("Unoptimised: {0}", sw.Elapsed);
        sw.Restart();

        for (int count = 0; count < 10; count++)
        {
            var ads = context.Ads
            .Where(a => a.AdStatus != null && a.AdStatus.Status == "Published")
            .Select(a => new
            {
                Title = a.Title,
                Category = a.Category != null ? a.Category.Name : "(null)",
                Town = a.Town != null ? a.Town.Name : "(null)",
                PublishDate = a.Date
            })
            .OrderBy(a => a.PublishDate)
            .ToList();
        }

        // Optimised: 0.5 seconds
        Console.WriteLine("Optimised: {0}", sw.Elapsed);
        sw.Stop();
    }
}