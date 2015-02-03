using System;
using System.Collections.Generic;

namespace MultimediaShop.Interfaces
{
    public interface IItem
    {
        string Id { get; }
        string Title { get; }
        decimal Price { get; }
        List<string> Genres { get; }

    }
}
