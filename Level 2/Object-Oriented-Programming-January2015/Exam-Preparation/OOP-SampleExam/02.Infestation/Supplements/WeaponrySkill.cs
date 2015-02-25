namespace Infestation.Supplements
{
    using System;

    class WeaponrySkill : ISupplement
    {
        private int powerEffect = 0;
        private int healthEffect = 0;
        private int aggressionEffect = 0;

        public void ReactTo(ISupplement otherSupplement)
        {
        }

        public int PowerEffect
        {
            get
            {
                return this.powerEffect;
            }
        }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }
        }

        public int AggressionEffect
        {
            get
            {
                return this.aggressionEffect;
            }
        }
    }
}
