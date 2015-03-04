namespace MyTunesShop.Models.Media
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Song : ISong
    {
        private static readonly int MinYear = DateTime.MinValue.Year;
        private static readonly int MaxYear = DateTime.Now.Year;

        private string title;
        private decimal price;
        private IPerformer performer;
        private string genre;
        private int year;
        private string duration;
        private IList<int> ratings = new List<int>();

        public Song(string title, decimal price, IPerformer performer, string genre, int year, string duration)
        {
            this.Title = title;
            this.Price = price;
            this.Performer = performer;
            this.Genre = genre;
            this.Year = year;
            this.Duration = duration;
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The title of a song is required.");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price of a song must be non-negative.");
                }

                this.price = value;
            }
        }

        public IPerformer Performer
        {
            get
            {
                return this.performer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The performer of a song is required.");
                }

                this.performer = value;
            }
        }

        public string Genre
        {
            get
            {
                return this.genre;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The genre of a song is required.");
                }

                this.genre = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            private set
            {
                if (value < MinYear || value > MaxYear)
                {
                    throw new ArgumentException(string.Format("The year of a song must be between {0} and {1}.", MinYear, MaxYear));
                }

                this.year = value;
            }
        }

        public string Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The duration of a song is required.");
                }

                this.duration = value;
            }
        }
        public IList<int> Ratings
        {
            get
            {
                return this.ratings;
            }
        }

        public void PlaceRating(int rating)
        {
            this.Ratings.Add(rating);
        }

        public override string ToString()
        {
            decimal average = 0;
            if (this.Ratings.Any())
            {
                for (int index = 0; index < this.Ratings.Count; index++)
                {
                    average += this.Ratings[index];
                }

                average /= this.Ratings.Count;   
            }

            

            string result =
                 string.Format("{0} ({1}) by {2}" + Environment.NewLine +
                              "Genre: {3}, Price: ${4:F2}" + Environment.NewLine +
                              "Rating: {5:F0}",
                              this.Title,
                              this.Year,
                              this.Performer.Name,
                              this.Genre,
                              this.Price,
                              average);

            return result;
        }
    }
}
