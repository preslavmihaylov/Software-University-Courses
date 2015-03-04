namespace MyTunesShop.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IRateable
    {
        IList<int> Ratings { get; }

        void PlaceRating(int rating);
    }
}
