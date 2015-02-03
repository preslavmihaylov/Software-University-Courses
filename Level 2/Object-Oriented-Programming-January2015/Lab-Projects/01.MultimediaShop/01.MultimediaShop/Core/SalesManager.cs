using MultimediaShop.Interfaces;
using MultimediaShop.Models.ServicesData;
using System;
using System.Collections.Generic;

namespace MultimediaShop.Core
{
    public static class SalesManager
    {
        private static List<ISales> sales = new List<ISales>();

        public static List<ISales> SalesList
        {
            get
            {
                return sales;
            }
        }

        public static void CreateSales(ISales sale)
        {
            SalesManager.SalesList.Add(sale);
        }
    }
}
