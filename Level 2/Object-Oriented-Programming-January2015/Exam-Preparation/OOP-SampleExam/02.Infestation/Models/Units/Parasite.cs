namespace Infestation.Models.Units
{
    using System.Collections.Generic;
    using System.Linq;

    class Parasite : Unit
    {
        private const int BaseHealth = 1;
        private const int BasePower = 1;
        private const int BaseAggression = 1;
        private const UnitClassification UnitType = UnitClassification.Biological;

        public Parasite(string id)
            : base(id, UnitType, BaseHealth, BasePower, BaseAggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.Id != unit.Id);

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health && 
                    InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) == this.UnitClassification)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
