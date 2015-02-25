namespace Estates.Data
{
    using System;
    using System.Linq;
    using Engine;
    using Interfaces;

    class ModifiedEstateEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "create":
                    return ExecuteCreateCommand(cmdArgs);
                case "status":
                    return ExecuteStatusCommand();
                case "find-sales-by-location":
                    return this.ExecuteFindSalesByLocationCommand(cmdArgs[0]);
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(cmdArgs[0], cmdArgs[1]);
                default:
                    throw new NotImplementedException("Unknown command: " + cmdName);
            }
        }

        private string ExecuteFindRentsByPriceCommand(string minPrice, string maxPrice)
        {
            decimal minPriceValue = decimal.Parse(minPrice);
            decimal maxPriceValue = decimal.Parse(maxPrice);

            var offers = this.Offers
                .Where(o => o.Type == OfferType.Rent)
                .Where(o =>
                {
                    IRentOffer rent = o as IRentOffer;

                    return rent.PricePerMonth >= minPriceValue && rent.PricePerMonth <= maxPriceValue;
                })
                .OrderBy(o =>
                {
                    IRentOffer rent = o as IRentOffer;
                    return rent.PricePerMonth;
                })
                .ThenBy(o => o.Estate.Name);

            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);

            return FormatQueryResults(offers);
        }

        private string ExecuteFindSalesByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Sale)
                .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }
    }
}
