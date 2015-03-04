namespace MyTunesShop.Engine
{
    using System;
    using System.Linq;
    using Interfaces;
    using Models.Media;
    using Models.Performers;

    public class ModifiedMyTunesEngine : MyTunesEngine
    {
        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "performer":
                    this.ExecuteInsertPerformerCommand(commandWords);
                    break;
                case "media":
                    this.ExecuteInsertMediaCommand(commandWords);
                    break;
                case "song_to_album":
                    this.ExecuteInsertSongToAlbumCommand(commandWords);
                    break;
                case "member_to_band":
                    this.ExecuteInsertPerformerToBandCommand(commandWords);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            base.ExecuteInsertPerformerCommand(commandWords);

            switch (commandWords[2])
            {
                case "band":
                    var band = new Band(commandWords[3]);
                    this.InsertPerformer(band);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            base.ExecuteInsertMediaCommand(commandWords);

            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    var album = new Album(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        performer,
                        commandWords[6],
                        int.Parse(commandWords[7]));
                    this.InsertAlbum(album, performer);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song":
                    var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[2]);
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[song].Supply(quantity);
                    this.Printer.PrintLine("{0} items of song {1} successfully supplied.", quantity, song.Title);
                    break;
                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int albumQuantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(albumQuantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", albumQuantity, album.Title);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song":
                    var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[2]);
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[song].Sell(quantity);
                    this.Printer.PrintLine("{0} items of song {1} successfully sold.", quantity, song.Title);
                    break;
                case "album":
                    var album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int albumQuantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(albumQuantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", albumQuantity, album.Title);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteRateCommand(string[] commandWords)
        {
            // rate:song;<name>;<rating> 
            switch (commandWords[1])
            {
                case "song":
                    var song = base.media.Where(s => s is ISong).FirstOrDefault(s => s.Title == commandWords[2]) as ISong;
                    song.PlaceRating(int.Parse(commandWords[3]));
                    base.Printer.PrintLine("The rating has been placed successfully.");
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "song":
                    var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[3]) as ISong;
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }
                    else
                    {
                        this.Printer.PrintLine(song.ToString());
                        var songSalesInfo = this.mediaSupplies[song];
                        this.Printer.PrintLine("Supplies: " + songSalesInfo.Supplies + ", Sold: " + songSalesInfo.QuantitySold);
                    }
                    break;
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }
                    else
                    {
                        this.Printer.PrintLine(album.ToString());
                        var albumSalesInfo = this.mediaSupplies[album];
                        this.Printer.PrintLine("Supplies: " + albumSalesInfo.Supplies + ", Sold: " + albumSalesInfo.QuantitySold);

                        if (album.Songs.Any())
                        {
                            this.Printer.PrintLine("Songs:");
                            foreach (var albumSong in album.Songs)
                            {
                                this.Printer.PrintLine(albumSong.Title + " (" + albumSong.Duration + ")");
                            }
                        }
                        else
                        {
                            this.Printer.PrintLine("No songs");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "singer":
                    var singer = this.performers.FirstOrDefault(p => p is Singer && p.Name == commandWords[3]) as Singer;
                    if (singer == null)
                    {
                        this.Printer.PrintLine("The singer does not exist in the database.");
                        return;
                    }
                    else
                    {
                        this.Printer.PrintLine(this.GetSingerReport(singer));   
                    }
                    break;
                case "band":
                    var band = this.performers.FirstOrDefault(p => p is IBand && p.Name == commandWords[3]) as IBand;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }
                    else
                    {
                        this.Printer.PrintLine(band.ToString());
                    }
                    break;
                default:
                    break;
            }
        }

        private void ExecuteInsertSongToAlbumCommand(string[] commandWords)
        {
            var album = base.media.Where(m => m is IAlbum).FirstOrDefault(m => m.Title == commandWords[2]);
            var song = base.media.Where(m => m is ISong).FirstOrDefault(m => m.Title == commandWords[3]);

            if (album != null)
            {
                if (song != null)
                {
                    (album as IAlbum).AddSong(song as ISong);

                    base.Printer.PrintLine("The song " + (song as ISong).Title +
                        " has been added to the album " + (album as IAlbum).Title + ".");
                }
                else
                {
                    throw new InvalidOperationException("The song does not exist in the database.");
                }
            }
            else
            {
                throw new InvalidOperationException("The album does not exist in the database.");
            }
        }

        private void ExecuteInsertPerformerToBandCommand(string[] commandWords)
        {
            // insert:member_to_band;<band_name>;<performer_name>.  
            var band = base.performers.Where(p => p is IBand).FirstOrDefault(p => (p as IBand).Name == commandWords[2]);
            if (band != null)
            {
                (band as IBand).AddMember(commandWords[3]);
                base.Printer.PrintLine("The member " + commandWords[3] + " has been added to the band " + (band as IBand).Name + ".");
            }
            else
            {
                throw new InvalidOperationException("The band does not exist in the database.");
            }
        }

        private void InsertAlbum(IAlbum album, IPerformer performer)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, performer.Name);
        }
    }
}
