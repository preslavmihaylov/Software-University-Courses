namespace Estates.Models.Estates
{
    using Interfaces;

    class Office : BuildingEstate, IOffice
    {
        public Office()
            : base(EstateType.Office)
        {   
        }
    }
}
