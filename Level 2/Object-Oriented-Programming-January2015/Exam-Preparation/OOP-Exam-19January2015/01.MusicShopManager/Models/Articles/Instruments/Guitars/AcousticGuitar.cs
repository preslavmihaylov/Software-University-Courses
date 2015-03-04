namespace MusicShop.Models.Articles.Instruments.Guitars
{
    using System;
    using MusicShopManager.Interfaces;
    using MusicShopManager.Models;

    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        public AcousticGuitar(
            string make,
            string model, 
            decimal price,
            string color, 
            string bodyWood,
            string fingerboardWood,
            bool caseIncluded, 
            StringMaterial material)
            : base(make, model, price, color, false, bodyWood, fingerboardWood, 6)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = material;
        }

        public bool CaseIncluded
        {
            get;
            private set;
        }

        public StringMaterial StringMaterial
        {
            get;
            private set; // TODO: Possible error
        }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format(Environment.NewLine + 
                                 "Case included: {0}" + Environment.NewLine +
                                 "String material: {1}",
                                 this.CaseIncluded ? "yes" : "no",
                                 this.StringMaterial.ToString());
        }
    }
}
