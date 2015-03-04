namespace NightlifeEntertainment.Models.Tickets
{
    using System;
    using Interfaces;

    public class RegularTicket : Ticket
    {
        public RegularTicket(IPerformance performance)
            : base(performance, TicketType.Regular)
        {
        }
    }
}
