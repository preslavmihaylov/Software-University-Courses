namespace Infestation.Supplements
{
    class Weapon : ISupplement
    {
        private int powerEffect = 0;
        private int healthEffect = 0;
        private int aggressionEffect = 0;

        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill && this.powerEffect == 0 && this.aggressionEffect == 0)
            {
                this.powerEffect = 10;
                this.aggressionEffect = 3;
            }
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
