using MultimediaShop.Enumerations;
using MultimediaShop.Interfaces;
using MultimediaShop.Models.Items;
using System;
using System.Text;

namespace MultimediaShop.Models.ServicesData
{
    public class Rent : IRent
    {
        private IItem item;
        private RentState rentState;
        private DateTime rentDate;
        private DateTime deadline;
        private DateTime dateOfReturn;

        public Rent(IItem item, DateTime rentDate, DateTime deadline)
        {
            this.Item = item;
            this.RentDate = rentDate;
            this.Deadline = deadline;
            this.RentState = RentState.Pending;
        }

        public Rent(IItem item, DateTime rentDate)
        {
            this.Item = item;
            this.RentDate = rentDate;
            this.Deadline = rentDate.AddDays(30);
            this.RentState = RentState.Pending;
        }

        public Rent(IItem item)
        {
            this.Item = item;
            this.RentDate = DateTime.Now;
            this.Deadline = this.RentDate.AddDays(30);
            this.RentState = RentState.Pending;
        }

        private bool HasOverdued { get; set; }

        public IItem Item
        {
            get 
            {
                return this.item;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The rent item cannot be null.");
                }
                this.item = value;
            }
        }

        public RentState RentState
        {
            get 
            {
                if (DateTime.Now > this.Deadline && this.rentState != RentState.Returned)
                {
                    this.RentState = RentState.Overdue;
                    this.HasOverdued = true;
                }

                return this.rentState;
            }
            private set
            {
                this.rentState = value;
            }
        }

        public DateTime RentDate
        {
            get 
            {
                return this.rentDate;
            }
            private set
            {
                this.rentDate = value;
            }
        }

        public DateTime Deadline
        {
            get 
            {
                return this.deadline;
            }
            private set
            {
                this.deadline = value;
            }
        }

        public DateTime DateOfReturn
        {
            get
            {
                return this.dateOfReturn;
            }
            private set
            {
                this.dateOfReturn = value;
            }
        }

        public void ReturnItem()
        {
            if (this.RentState != RentState.Returned)
            {
                this.RentState = RentState.Returned;
                this.DateOfReturn = DateTime.Now;
            }
        }

        public decimal CalculateRentFine()
        {
            TimeSpan overduePeriod;

            if (this.RentState == RentState.Returned && this.HasOverdued)
            {
                overduePeriod = this.DateOfReturn.Subtract(this.Deadline);
            }
            else if (this.RentState == RentState.Overdue) 
            {
                overduePeriod = DateTime.Now.Subtract(this.Deadline);
            }
            else
            {
                return 0m;
            }

            decimal fine = 0m;

            for (int index = 0; index < overduePeriod.Days; index++)
            {
                fine += 1 * this.Item.Price / 100;
            }

            return fine;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append("- Rent " + this.RentState + Environment.NewLine);
            output.Append(this.Item.GetType().Name + " " + this.Item.Id + Environment.NewLine);
            output.Append("Title: " + this.Item.Title + Environment.NewLine);
            output.Append("Price: " + this.Item.Price + Environment.NewLine);
            output.Append("Genres: " + String.Join(", ", this.Item.Genres) + Environment.NewLine);

            if (this.Item.GetType() == typeof(Book))
            {
                output.Append("Author: " + (this.Item as Book).Author);
            }
            else if (this.Item.GetType() == typeof(Game))
            {
                output.Append("Age restriction: " + (this.Item as Game).AgeRestriction);
            }
            else if (this.Item.GetType() == typeof(Book))
            {
                output.Append("Length: " + (this.Item as Movie).Length);
            }

            output.Append(Environment.NewLine + "Rent fine: " + this.CalculateRentFine() + Environment.NewLine);

            return output.ToString();
        }
    }
}
