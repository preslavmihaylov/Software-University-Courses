using MultimediaShop.Enumerations;
using MultimediaShop.Exceptions;
using MultimediaShop.Interfaces;
using MultimediaShop.Models.ServicesData;
using MultimediaShop.Models.Items;
using System;
using System.Collections.Generic;

namespace MultimediaShop.Core
{
    public class Engine
    {

        public void Run()
        {
            while (true)
            {
                string[] input = ParseInput(Console.ReadLine());
                if (input[0] == "end")
                {
                    return;
                }

                ExecuteCommand(input);
            }
        }

        private string[] ParseInput(string input)
        {
            return input.Split(new[] { " ", "&" }, StringSplitOptions.None);
        }

        private void ExecuteCommand(string[] input)
        {
            IItem item = null;
            if (input[0] != "supply")
            {
                item = SupplyManager.GetItemByID(input[1]);
            }

            switch (input[0])
            {
                case "supply":
                    item = Item.Parse(input);
                    int quantity = int.Parse(input[2]);
                    SupplyManager.SupplyStock(item, quantity);
                    break;
                case "sell":
                    if (!SupplyManager.Supplies.ContainsKey(item))
                    {
                        Console.WriteLine("There is no such id");
                    }
                    else if (SupplyManager.Supplies[item] <= 0)
                    {
                        throw new InsufficientSuppliesException();
                    }
                    SupplyManager.Supplies[item]--;

                    if (input.Length >= 3)
                    {
                        DateTime dateOfPurchase = DateTime.Parse(input[2]);
                        SalesManager.CreateSales(new Sales(item, dateOfPurchase));   
                    }
                    else
                    {
                        SalesManager.CreateSales(new Sales(item)); 
                    }
                    break;
                case "rent":
                    if (!SupplyManager.Supplies.ContainsKey(item))
                    {
                        Console.WriteLine("There is no such id");
                    }
                    else if (SupplyManager.Supplies[item] <= 0)
                    {
                        throw new InsufficientSuppliesException();
                    }
                    else
                    {
                        IRent rent = ParseRentCommand(input, item);
                        RentManager.CreateRent(rent);
                        SupplyManager.Supplies[item]--;
                    }
                    break;
                case "return":
                    int exitCode = RentManager.ReturnItem(item);
                    if (exitCode == 0)
                    {
                        SupplyManager.Supplies[item]++;
                    }
                    break;
                case "report":
                    if (input[1] == "rents")
                    {
                        ReportManager.ReportRents();
                    }
                    else
                    {
                        DateTime startDate = DateTime.Parse(input[2]);
                        ReportManager.ReportSales(startDate);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

        private static IRent ParseRentCommand(string[] input, IItem item)
        {
            IRent rent;

            if (input.Length == 2)
            {
                rent = new Rent(item);
            }
            else if (input.Length == 3)
            {
                DateTime rentDate = DateTime.Parse(input[2]);
                rent = new Rent(item, rentDate);
            }
            else
            {
                DateTime rentDate = DateTime.Parse(input[2]);
                DateTime deadline = DateTime.Parse(input[3]);
                rent = new Rent(item, rentDate, deadline);
            }

            return rent;
        }
    }
}
