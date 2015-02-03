using System;

namespace MultimediaShop.Interfaces
{
    public interface ISales
    {
        IItem Item { get; }
        DateTime DateOfPurchase { get; }
    }
}
