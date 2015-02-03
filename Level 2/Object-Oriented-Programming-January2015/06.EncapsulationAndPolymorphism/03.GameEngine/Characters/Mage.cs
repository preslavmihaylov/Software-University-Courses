using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    class Mage : Character, IAttack
    {
        public int AttackPoints { get; set; }

        public Mage(string id, int x, int y, Team team) 
            : base(id, x, y, 150, 50, team, 5)
        {
            this.AttackPoints = 300;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var targets = targetsList.Select(c => c)
                .Where(c => c.IsAlive == true)
                .Where(c => c.Id != this.Id);

            if (targets.Count() > 0)
            {
                return targets.Last();
            }

            return null;
        }

        public override void AddToInventory(Item item)
        {
            this.ApplyItemEffects(item);
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.RemoveItemEffects(item);
            this.Inventory.Remove(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.HealthPoints -= item.HealthEffect;
            this.DefensePoints -= item.DefenseEffect;
            this.AttackPoints -= item.AttackEffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " Attack Points: " + this.AttackPoints;
        }
    }
}
