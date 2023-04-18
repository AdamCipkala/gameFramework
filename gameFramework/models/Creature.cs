using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    /// <summary>
    /// Represents a creature in the game world.
    /// </summary>
    public class Creature
    {
        /// <summary>
        /// Gets or sets the name of the creature.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hit points of the creature.
        /// </summary>
        public int HitPoints { get; set; }

        /// <summary>
        /// Gets or sets the attack items of the creature.
        /// </summary>
        public List<AttackItem> AttackItems { get; set; }

        /// <summary>
        /// Gets or sets the defence items of the creature.
        /// </summary>
        public List<DefenceItem> DefenceItems { get; set; }

        /// <summary>
        /// Gets or sets the position of the creature in the game world.
        /// </summary>
        public Position Position { get; set; }

        private static readonly TraceSwitch _traceSwitch = new TraceSwitch("CreatureTraceSwitch", "Switch for creature tracing", TraceLevel.Info.ToString());

        /// <summary>
        /// Hits the specified target creature, dealing damage based on the creature's attack items and the target's defence items.
        /// </summary>
        /// <param name="target">The target creature to hit.</param>
        public void Hit(Creature target)
        {
            int damage = AttackItems.Sum(item => item.HitPoints) - target.DefenceItems.Sum(item => item.ReduceHitPoints);
            damage = Math.Max(damage, 0);
            target.ReceiveHit(damage);

            TraceMessage("hit a target");
        }

        /// <summary>
        /// Receives damage from an attack, reducing the creature's hit points. If the creature's hit points reach zero or less, the creature is removed from the game world.
        /// </summary>
        /// <param name="damage">The amount of damage to receive.</param>
        public void ReceiveHit(int damage)
        {
            this.HitPoints -= damage;
            if (this.HitPoints <= 0)
            {
                World.Creatures.Remove(this);
            }
        }

        /// <summary>
        /// Picks up the specified world object and adds it to the creature's inventory. If the world object is an attack item, it is added to the creature's attack items. If it is a defence item, it is added to the creature's defence items.
        /// </summary>
        /// <param name="worldObject">The world object to pick up.</param>
        public void Pick(WorldObject worldObject)
        {
            if (worldObject is AttackItem attackItem)
            {
                AttackItems.Add(attackItem);
            }
            else if (worldObject is DefenceItem defenceItem)
            {
                DefenceItems.Add(defenceItem);
            }

            World.WorldObjects.Remove(worldObject);
            TraceMessage("picked up an object");
        }

        private static void TraceMessage(string message)
        {
            if (_traceSwitch.TraceInfo)
            {
                Trace.TraceInformation("[Creature] " + message);
            }
            else if (_traceSwitch.TraceWarning)
            {
                Trace.TraceWarning("[Creature] " + message);
            }
            else if (_traceSwitch.TraceError)
            {
                Trace.TraceError("[Creature] " + message);
            }
        }
    }
}
