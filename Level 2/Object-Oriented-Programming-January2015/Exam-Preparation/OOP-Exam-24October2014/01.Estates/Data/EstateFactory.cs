using Estates.Engine;
using Estates.Interfaces;
using System;

namespace Estates.Data
{
    using Models.Estates;
    using Models.Offers;

    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new ModifiedEstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Office:
                    return new Office();
                case EstateType.Apartment:
                    return new Apartment();
                case EstateType.Garage:
                    return new Garage();
                case EstateType.House:
                    return new House();
                default:
                    throw new NotImplementedException("There is no such estate type.");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Rent:
                    return new Rent();
                case OfferType.Sale:
                    return new Sale();
                default:
                    throw new NotImplementedException("The is no such offer type.");
            }
        }
    }
}
