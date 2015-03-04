namespace NightlifeEntertainment.Models.Venues
{
    using System.Collections.Generic;

    class ConcertHall : Venue
    {
        public ConcertHall(string name, string location, int numberOfSeats)
            : base(
                name,
                location, 
                numberOfSeats, 
                new List<PerformanceType> { PerformanceType.Opera, PerformanceType.Theatre, PerformanceType.Concert })
        {
        }
    }
}
