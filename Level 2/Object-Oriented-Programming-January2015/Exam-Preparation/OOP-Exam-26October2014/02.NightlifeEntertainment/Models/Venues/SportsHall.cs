namespace NightlifeEntertainment.Models.Venues
{
    using System.Collections.Generic;

    class SportsHall : Venue
    {
        public SportsHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Sport, PerformanceType.Concert })
        {
        }
    }
}
