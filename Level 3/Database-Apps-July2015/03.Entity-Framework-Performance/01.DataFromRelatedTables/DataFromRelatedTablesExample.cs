using System;
using System.Data.Entity;
using System.Linq;
using _01.DataFromRelatedTables;

class DataFromRelatedTablesExample
{
    static void Main()
    {
        var context = new AdsEntities();

        var ads = context.Ads.Select(a => a);

        // Without Include. - Around ~15 queries
        foreach (var ad in ads)
        {
            Console.WriteLine(" --- Title: {0} - Status: {1} - Category: {2}",
                ad.Title, 
                ad.AdStatus != null ? ad.AdStatus.Status : "(null)" , 
                ad.Category != null ? ad.Category.Name : "(null)");
        
            Console.WriteLine("  -- Town: {0} - Author: {1}",
                ad.Town != null ? ad.Town.Name : "(null)",
                ad.AspNetUser != null ? ad.AspNetUser.UserName : "(null)");
        }

        var adsWithInclude = context.Ads
            .Select(a => a)
            .Include(a => a.Town)
            .Include(a => a.AdStatus)
            .Include(a => a.Category)
            .Include(a => a.AspNetUser);

        // With Include. Only 1 query
        foreach (var ad in adsWithInclude)
        {
            Console.WriteLine(" --- Title: {0} - Status: {1} - Category: {2}",
                ad.Title,
                ad.AdStatus != null ? ad.AdStatus.Status : "(null)",
                ad.Category != null ? ad.Category.Name : "(null)");

            Console.WriteLine("  -- Town: {0} - Author: {1}",
                ad.Town != null ? ad.Town.Name : "(null)",
                ad.AspNetUser != null ? ad.AspNetUser.UserName : "(null)");
        }

    }
}