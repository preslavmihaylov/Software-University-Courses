using MultimediaShop.Enumerations;
using System;
using System.Linq;

namespace MultimediaShop.Core
{
    public static class ReportManager
    {
        public static void ReportRents()
        {
            var overdueRents = RentManager.RentsList
                .Select(r => r)
                .Where(r => r.RentState == RentState.Overdue)
                .OrderBy(r => r.CalculateRentFine())
                .ThenBy(r => r.Item.Title);

            foreach (var rent in overdueRents)
            {
                Console.WriteLine();
                Console.WriteLine(rent.ToString());
            }

            Console.WriteLine();
        }

        public static void ReportSales(DateTime startdate)
        {
            var sales = SalesManager.SalesList
                .Select(s => s)
                .Where(s => s.DateOfPurchase > startdate)
                .OrderBy(s => s.Item.Title);

            foreach (var sale in sales)
            {
                Console.WriteLine();
                Console.WriteLine(sale.ToString());
            }

            Console.WriteLine();
        }
    }
}
