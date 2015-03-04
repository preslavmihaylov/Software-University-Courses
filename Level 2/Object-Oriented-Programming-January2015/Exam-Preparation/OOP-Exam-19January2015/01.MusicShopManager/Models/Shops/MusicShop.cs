namespace MusicShop.Models.Shops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MusicShopManager.Interfaces;

    public class MusicShop : IMusicShop
    {
        private string name;
        private IList<IArticle> articles = new List<IArticle>();

        public MusicShop(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Name is required.");
                }
                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get
            {
                return this.articles;
            }
        }

        public void AddArticle(IArticle article)
        {
            // TODO: Possible error, validate input
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            if (this.Articles.Contains(article))
            {
                this.Articles.Remove(article);
            }
        }

        public string ListArticles()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("===== {0} =====" + Environment.NewLine, this.Name);

            if (!this.Articles.Any())
            {
                output.AppendLine("The shop is empty. Come back soon."); // TODO: Possible error, remove new line
            }
            else
            {
                var microphones = this.Articles
                                    .Where(a => a is IMicrophone)
                                    .OrderBy(a => a.Make)
                                    .ThenBy(a => a.Model);

                var drums = this.Articles
                                    .Where(a => a is IDrums)
                                    .OrderBy(a => a.Make)
                                    .ThenBy(a => a.Model);

                var electricGuitars = this.Articles
                                    .Where(a => a is IElectricGuitar)
                                    .OrderBy(a => a.Make)
                                    .ThenBy(a => a.Model);

                var acousticGuitars = this.Articles
                                    .Where(a => a is IAcousticGuitar)
                                    .OrderBy(a => a.Make)
                                    .ThenBy(a => a.Model);

                var bassGuitars = this.Articles
                                    .Where(a => a is IBassGuitar)
                                    .OrderBy(a => a.Make)
                                    .ThenBy(a => a.Model);

                if (microphones.Any())
                {
                    output.AppendLine("----- Microphones -----");
                    foreach (var microphone in microphones)
                    {
                        output.AppendLine(microphone.ToString());
                    }
                }

                if (drums.Any())
                {
                    output.AppendLine("----- Drums -----");
                    foreach (var drum in drums)
                    {
                        output.AppendLine(drum.ToString());
                    }
                }

                if (electricGuitars.Any())
                {
                    output.AppendLine("----- Electric guitars -----");
                    foreach (var electricGuitar in electricGuitars)
                    {
                        output.AppendLine(electricGuitar.ToString());
                    }
                }

                if (acousticGuitars.Any())
                {
                    output.AppendLine("----- Acoustic guitars -----");
                    foreach (var acousticGuitar in acousticGuitars)
                    {
                        output.AppendLine(acousticGuitar.ToString());
                    }
                }

                if (bassGuitars.Any())
                {
                    output.AppendLine("----- Bass guitars -----");
                    foreach (var bassGuitar in bassGuitars)
                    {
                        output.AppendLine(bassGuitar.ToString());
                    }
                }
            }

            return output.ToString();
        }
    }
}
