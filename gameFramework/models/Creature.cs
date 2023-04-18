using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public class Creature
    {
        private string Name { get; set; }
        private int HitPoints { get; set; }
        private List<AttackItem> AttackItems { get; set; }
        private List<DefenceItem> DefenceItems { get; set; }

        private Position Position { get; set; }

        private void Hit(Creature target)
        {
            // Implementation of creature hitting another creature
        }

        private void ReceiveHit(AttackItem attackObject)
        {
            // Implementation of creature receiving hit from an attack object
        }

        private void Pick(WorldObject worldObject)
        {
            // Implementation of creature picking up an object from the world
        }
    }
}
