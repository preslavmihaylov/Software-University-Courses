namespace Estates.Models.Estates
{
    using System;
    using Interfaces;

    abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;

        protected BuildingEstate(EstateType type)
            : base(type)
        {
        }

        public int Rooms
        {
            get
            {
                return this.rooms;
            }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("The number of rooms cannot be negative or above 20.");
                }

                this.rooms = value;
            }
        }

        public bool HasElevator
        {
            get;
            set;
        }

        public override string ToString()
        {
            string output = string.Format(", Rooms: {0}, Elevator: {1}",
                this.Rooms,
                this.HasElevator ? "Yes" : "No");

            return base.ToString() + output;
        }
    }
}
