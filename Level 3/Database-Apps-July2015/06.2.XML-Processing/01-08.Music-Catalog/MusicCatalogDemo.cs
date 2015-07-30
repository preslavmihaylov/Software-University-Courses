using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

class MusicCatalogDemo
{
    static void Main()
    {
        XDocument doc = XDocument.Load("../../catalog.xml");

        /*
         * Problem 2.	DOM Parser: Extract Album Names
         */

        var albums = doc.Descendants("album");

        Console.WriteLine(new string('-', 60));
        Console.WriteLine("Problem 2.	DOM Parser: Extract Album Names:");
        Console.WriteLine(new string('-', 60));
        foreach (var album in albums)
        {
            Console.WriteLine(album.Attribute("title").Value);
        }

        Console.WriteLine(new string('-', 60));

        /*
         * Problem 3.	DOM Parser: Extract All Artists Alphabetically
         */

        var artistsAlphabetically = doc.Descendants("artist")
            .OrderBy(a => a.Attribute("name").Value)
            .Select(a => a.Attribute("name").Value);

        Console.WriteLine("Problem 3.	DOM Parser: Extract All Artists Alphabetically");
        Console.WriteLine(new string('-', 60));

        foreach (var artistName in artistsAlphabetically)
        {
            Console.WriteLine(artistName);
        }

        Console.WriteLine(new string('-', 60));

        /*
         * Problem 4.	DOM Parser: Extract Artists and Number of Albums
         */

        var artistsWithNumberOfAlbums = doc.Descendants("artist")
            .Select(a => new
            {
                Name = a.Attribute("name").Value,
                AlbumsCount = a.Descendants("album").Count()
            });

        Console.WriteLine("Problem 4.	DOM Parser: Extract Artists and Number of Albums");
        Console.WriteLine(new string('-', 60));

        foreach (var artist in artistsWithNumberOfAlbums)
        {
            Console.WriteLine(artist.Name + " --> " + artist.AlbumsCount);
        }

        Console.WriteLine(new string('-', 60));

        /*
         * Problem 5.	XPath: Extract Artists and Number of Albums
         */

        var artistsWithNumberOfAlbumsXPath = doc.XPathSelectElements("music/artist");

        Console.WriteLine("Problem 5.	XPath: Extract Artists and Number of Albums");
        Console.WriteLine(new string('-', 60));

        foreach (var artist in artistsWithNumberOfAlbumsXPath)
        {
            Console.WriteLine(artist.Attribute("name") + " --> " + artist.Descendants("album").Count());
        }

        Console.WriteLine(new string('-', 60));

        /*
         * Problem 6.	DOM Parser: Delete Albums
         */

        var albumsToDelete = doc.XPathSelectElements("music/artist/album[@price > 20]");

        Console.WriteLine("Problem 6.	DOM Parser: Delete Albums");
        Console.WriteLine(new string('-', 60));

        Console.WriteLine("Deleted " + albumsToDelete.Count());

        // albumsToDelete.Remove();
        // doc.Save("../../catalog.xml");

        Console.WriteLine(new string('-', 60));

        /*
         * Problem 8.	LINQ to XML: Old Albums
         */

        var oldAlbums = doc.Descendants("album")
            .Where(a => DateTime.Parse(a.Attribute("date").Value) < DateTime.Now.AddYears(-5))
            .Select(a => new
            {
                Title = a.Attribute("title"),
                Price = a.Attribute("price")
            });

        Console.WriteLine("Problem 8.	LINQ to XML: Old Albums");
        Console.WriteLine(new string('-', 60));

        foreach (var oldAlbum in oldAlbums)
        {
            Console.WriteLine("Title: " + oldAlbum.Title.Value + ", Price: " + oldAlbum.Price.Value);
        }

        Console.WriteLine(new string('-', 60));

    }
}