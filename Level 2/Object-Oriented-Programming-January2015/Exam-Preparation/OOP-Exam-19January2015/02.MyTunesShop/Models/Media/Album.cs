namespace MyTunesShop.Models.Media
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Album : IAlbum
    {
        private IList<ISong> songs = new List<ISong>(); 

        public Album(string title, decimal price, IPerformer performer, string genre, int year)
        {
            this.Title = title;
            this.Price = price;
            this.Performer = performer;
            this.Genre = genre;
            this.Year = year;
        }

        public string Title
        {
            get;
            private set;
        }

        public decimal Price
        {
            get;
            private set;
        }

        public IPerformer Performer
        {
            get;
            private set;
        }

        public string Genre
        {
            get;
            private set;
        }

        public int Year
        {
            get;
            private set;
        }

        public IList<ISong> Songs
        {
            get
            {
                return this.songs;
            }
        }

        public void AddSong(ISong song)
        {
            this.Songs.Add(song);
        }

        public override string ToString()
        {
           // <title> (<year>) by <performer_name>
           // Genre: <genre>, Price:$<price>

            return
                string.Format("{0} ({1}) by {2}" + Environment.NewLine +
                              "Genre: {3}, Price: ${4:F2}",
                              this.Title,
                              this.Year,
                              this.Performer.Name,
                              this.Genre,
                              this.Price);
        }
    }
}
