using System;
using System.Collections.Generic;
using MultimediaShop.Enumerations;
using MultimediaShop.Interfaces;
using MultimediaShop.Models.ServicesData;

namespace MultimediaShop.Core
{
    public static class RentManager
    {
        private static List<IRent> rents = new List<IRent>();

        public static List<IRent> RentsList
        {
            get
            {
                return rents;
            }
        }

        public static void CreateRent(IRent rent) 
        {
            RentManager.RentsList.Add(rent);
        }

        public static int ReturnItem(IItem item) 
        {
            for (int index = 0; index < RentManager.RentsList.Count; index++)
            {
                if (RentManager.RentsList[index].Item == item)
                {
                    if (RentManager.RentsList[index].RentState == RentState.Returned)
                    {
                        Console.WriteLine("The item has already been returned.");
                        return 1;
                    }
                    RentManager.RentsList[index].ReturnItem();
                    break;
                }
            }
            return 0;
        }
    }
}
