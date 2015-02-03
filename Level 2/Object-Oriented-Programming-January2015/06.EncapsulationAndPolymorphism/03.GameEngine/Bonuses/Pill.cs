using System;

namespace TheSlum.Bonuses
{
    class Pill : Bonus
    {
        public Pill(string id)
            : base(id, 0, 0, 100)
        {
            this.Timeout = 1;
            this.Countdown = 1;
            this.HasTimedOut = false;
        }
    }
}
