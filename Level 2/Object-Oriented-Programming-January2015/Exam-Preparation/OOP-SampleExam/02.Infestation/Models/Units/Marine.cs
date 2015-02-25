namespace Infestation.Models.Units
{
    using System.Collections.Generic;
    using Supplements;

    class Marine : Human
    {
        private const int BaseHealth = 20;
        private const int BasePower = 25;
        private const int BaseAggression = 22;
        private const UnitClassification UnitType = UnitClassification.Mechanical;

        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health > optimalAttackableUnit.Health && unit.Power <= this.Aggression)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
