using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public class Creature
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public List<AttackItem> AttackItems { get; set; }
        public List<DefenceItem> DefenceItems { get; set; }

        public Position Position { get; set; }

        public bool IsDead { get; set; }

        public void Hit(Creature target)
        {
            int damage = 0;
            foreach (AttackItem item in AttackItems)
            {
                damage += item.HitPoints;
            }
            foreach (DefenceItem item in target.DefenceItems)
            {
                damage -= item.ReduceHitPoints;
            }
            damage = Math.Max(damage, 0);
            target.ReceiveHit(damage);
        }

        public void ReceiveHit(int damage)
        {
            this.HitPoints -= damage;
            if (this.HitPoints <= 0)
            {
                // TODO: Remove the creature from the game or simulation environment
                IsDead = true;
            }
        }

        public void Pick(WorldObject worldObject)
        {
            if (worldObject is AttackItem)
            {
               AttackItems.Add((AttackItem)worldObject);
            }
            else if (worldObject is DefenceItem)
            {
               DefenceItems.Add((DefenceItem)worldObject);
            }
            // TODO: Remove the object from the world
        }
    }
}
