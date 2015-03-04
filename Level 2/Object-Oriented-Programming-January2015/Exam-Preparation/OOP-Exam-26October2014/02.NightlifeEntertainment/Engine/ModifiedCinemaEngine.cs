namespace NightlifeEntertainment.Engine
{
    using System;
    using System.Linq;
    using Models.Performances;
    using Models.Tickets;
    using Models.Venues;

    class ModifiedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "cinema":
                    var cinema = new Cinema(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(cinema);
                    break;
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[5]);
            switch (commandWords[2])
            {
                case "movie":
                    var movie = new Movie(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        venue,
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(movie);
                    break;
                case "theatre":
                    var theatre = new Theatre(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        venue,
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concert = new Concert(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        venue,
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[2]);
            var performance = this.GetPerformance(commandWords[3]);
            if (performance.Venue.Name != venue.Name)
            {
                throw new ArgumentException("The performance doesn't match the venue specified");
            }

            switch (commandWords[1])
            {
                case "regular":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new RegularTicket(performance));
                    }

                    break;
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }

                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VIPTicket(performance));
                    }

                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[1]);
            var soldTickets = performance.Tickets.Where(t => t.Status == TicketStatus.Sold);
            var totalPrice = soldTickets.Sum(t => t.Price);
            var ticketsSold = soldTickets.Count();

            base.Output.AppendFormat(
                "{0}: {1} ticket(s), total: ${2:F2}" + Environment.NewLine +
                "Venue: {3} ({4})" + Environment.NewLine +
                "Start time: {5}" + Environment.NewLine,
                performance.Name,
                ticketsSold,
                totalPrice,
                performance.Venue.Name,
                performance.Venue.Location,
                performance.StartTime.ToString("MM/dd/yyyy HH:mm:ss"));
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            string phrase = commandWords[1].ToLower();
            DateTime startDate = DateTime.Parse(commandWords[2] + " " + commandWords[3]);
            base.Output.AppendLine("Search for \"" + commandWords[1] + "\"");

            var performancesMatch = this.Performances
                                    .Where(p => p.Name.ToLower().Contains(phrase))
                                    .Where(p => p.StartTime >= startDate)
                                    .OrderBy(p => p.StartTime)
                                    .ThenByDescending(p => p.BasePrice)
                                    .ThenBy(p => p.Name);

            var venuesMatch = this.Venues
                              .Where(v => v.Name.ToLower().Contains(phrase))
                              .OrderBy(v => v.Name);

            base.Output.AppendLine("Performances:");
            if (performancesMatch.Any())
            {
                foreach (var performance in performancesMatch)
                {
                    base.Output.AppendLine("-" + performance.Name);
                }
            }
            else
            {
                base.Output.AppendLine("no results");
            }

            base.Output.AppendLine("Venues:");
            if (venuesMatch.Any())
            {
                foreach (var venue in venuesMatch)
                {
                    base.Output.AppendLine("-" + venue.Name);
                    var performancesAtVenue = this.Performances
                                              .Where(p => p.Venue.Name == venue.Name)
                                              .Where(p => p.StartTime >= startDate)
                                              .OrderBy(p => p.StartTime)
                                              .ThenByDescending(p => p.BasePrice)
                                              .ThenBy(p => p.Name);

                    foreach (var performance in performancesAtVenue)
                    {
                        base.Output.AppendLine("--" + performance.Name);
                    }
                }
            }
            else
            {
                base.Output.AppendLine("no results");
            }
        }
    }
}
