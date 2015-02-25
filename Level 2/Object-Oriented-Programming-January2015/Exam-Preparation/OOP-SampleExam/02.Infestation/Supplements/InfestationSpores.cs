namespace Infestation.Supplements
{
    using System;

    class InfestationSpores : ISupplement
    {
        private int powerEffect = -1;
        private int healthEffect = 0;
        private int aggressionEffect = 20;

        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.powerEffect = 0;
                this.aggressionEffect = 0;
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
