using System;
using TheSlum.Interfaces;

namespace TheSlum.Bonuses
{
    class Injection : Bonus
    {
        public Injection(string id)
            : base(id, 200, 0, 0)
        {
            this.Timeout = 3;
            this.Countdown = 3;
            this.HasTimedOut = false;
        }
    }
}
