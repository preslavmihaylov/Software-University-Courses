using System;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    class Healer : Character, IHeal
    {
        public int HealingPoints { get; set; }

        public Healer(string id, int x, int y, Team team) 
            : base(id, x, y, 75, 50, team, 6)
        {
            this.HealingPoints = 60;
        }

        public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
        {
            var targets = targetsList.Select(c => c)
                .Where(c => c.IsAlive == true)
                .Where(c => c.Id != this.Id)
                .Where(c => c.Team == this.Team);

            if (targets.Count() > 0)
            {
                var minHealthChar = targets.Min(t => t.HealthPoints);
                return targetsList.First(t => t.HealthPoints == minHealthChar);
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

        public override string ToString()
        {
            return base.ToString() + " Healing Points: " + this.HealingPoints;
        }
    }
}
