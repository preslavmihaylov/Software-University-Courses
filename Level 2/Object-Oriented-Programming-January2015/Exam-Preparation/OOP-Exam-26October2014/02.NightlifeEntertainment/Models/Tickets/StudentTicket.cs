namespace NightlifeEntertainment.Models.Tickets
{
    using System;
    using Interfaces;

    class StudentTicket : Ticket
    {
        public StudentTicket(IPerformance performance)
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException("The price cannot be calculated because there is no performance for this ticket.");
            }

            return this.Performance.BasePrice - (this.Performance.BasePrice * 20 / 100);
        }
    }
}
