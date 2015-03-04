namespace MusicShop.Models.Articles.Instruments.Guitars
{
    using System;
    using MusicShopManager.Interfaces;

    public class BassGuitar : Guitar, IBassGuitar
    {
        public BassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood)
            : base(make, model, price, color, true, bodyWood, fingerboardWood, 4)
        {
        }

        public override int NumberOfStrings
        {
            get
            {
                return base.NumberOfStrings;
            }
            protected set
            {
                if (value != 4)
                {
                    throw new ArgumentException("The number of strings of a bass guitar can be only 4.");
                }
                base.numberOfStrings = value;
            }
        }
    }
}
