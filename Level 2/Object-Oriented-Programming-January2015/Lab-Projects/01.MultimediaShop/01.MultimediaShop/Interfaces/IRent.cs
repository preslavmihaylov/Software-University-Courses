using System;
using MultimediaShop.Enumerations;

namespace MultimediaShop.Interfaces
{
    public interface IRent
    {
        IItem Item { get; }
        RentState RentState { get; }
        DateTime RentDate { get; }
        DateTime Deadline { get; }
        DateTime DateOfReturn { get; }
        decimal CalculateRentFine();
        void ReturnItem();
    }
}
