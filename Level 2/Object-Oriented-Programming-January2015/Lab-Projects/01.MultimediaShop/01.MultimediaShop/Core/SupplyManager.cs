using MultimediaShop.Interfaces;
using System;
using System.Collections.Generic;

namespace MultimediaShop.Core
{
    public static class SupplyManager
    {
        private static Dictionary<IItem, int> supplies = new Dictionary<IItem, int>();

        public static Dictionary<IItem, int> Supplies
        {
            get
            {
                return SupplyManager.supplies;
            }
        }

        public static void SupplyStock(IItem item, int quantity)
        {
            if (SupplyManager.Supplies.ContainsKey(item))
            {
                SupplyManager.Supplies[item] += quantity;
            }
            else
            {
                SupplyManager.Supplies.Add(item, quantity);
            }
        }

        public static IItem GetItemByID(string id)
        {
            foreach (KeyValuePair<IItem, int> pair in SupplyManager.Supplies)
            {
                if (pair.Key.Id == id)
                {
                    return pair.Key;
                }
            }

            return null;
        }
    }
}
