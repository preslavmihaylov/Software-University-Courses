namespace Estates.Models.Estates
{
    using Interfaces;

    class Apartment : BuildingEstate, IApartment
    {
        public Apartment()
            : base(EstateType.Office)
        {   
        }
    }
}
