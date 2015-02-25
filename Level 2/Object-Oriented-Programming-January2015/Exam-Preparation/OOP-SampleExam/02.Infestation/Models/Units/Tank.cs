namespace Infestation.Models.Units
{
    class Tank : Unit
    {
        private const int BaseHealth = 20;
        private const int BasePower = 25;
        private const int BaseAggression = 25;
        private const UnitClassification UnitType = UnitClassification.Mechanical;

        public Tank(string id)
            : base(id, UnitType, BaseHealth, BasePower, BaseAggression)
        {
        }
    }
}
