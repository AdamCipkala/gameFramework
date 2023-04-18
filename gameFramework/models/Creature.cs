using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static readonly TraceSwitch _traceSwitch = new TraceSwitch("CreatureTraceSwitch", "Switch for creature tracing", TraceLevel.Info.ToString());

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

            TraceMessage("hit a target");
        }

        public void ReceiveHit(int damage)
        {
            this.HitPoints -= damage;
            if (this.HitPoints <= 0)
            {
                World.Creatures.Remove(this);
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
