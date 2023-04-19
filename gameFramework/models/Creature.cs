using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static gameFramework.models.Creature;

namespace gameFramework.models
{
    // Observer Pattern
    public interface ICreatureObserver
    {
        void Notify(Creature creature);
    }

    public class ScoreBoard : ICreatureObserver
    {
        public void Notify(Creature creature)
        {
            Console.WriteLine($"Scoreboard: {creature.Name} defeated, score: {World.Creatures.Count}");
        }
    }
    public class Creature
    {
      
        public string Name { get; set; }
    
        public int HitPoints { get; set; }

        public List<AttackItem> AttackItems { get; set; }
       
        public List<DefenceItem> DefenceItems { get; set; }
      
        public Position Position { get; set; }

        private static readonly TraceSwitch _traceSwitch = new TraceSwitch("CreatureTraceSwitch", "Switch for creature tracing", TraceLevel.Info.ToString());

        private readonly ItemFactory _itemFactory = new NormalItemFactory();

        private readonly List<ICreatureObserver> _observers = new List<ICreatureObserver>();

        public Creature()
        {
            HitPoints = 100;
            AttackItems = new List<AttackItem>();
            DefenceItems = new List<DefenceItem>();
        }

        public void Hit(Creature target)
        {
            int damage = AttackItems.Sum(item => item.HitPoints) - target.DefenceItems.Sum(item => item.ReduceHitPoints);
            damage = Math.Max(damage, 0);
            target.ReceiveHit(damage);

            TraceMessage("hit a target");
        }

        public void ReceiveHit(int damage)
        {
            this.HitPoints -= damage;
            if (this.HitPoints <= 0)
            {
                NotifyObservers();
                World.Creatures.Remove(this);
            }
        }
      
        public void Pick(WorldObject worldObject)
        {
            if (worldObject is AttackItem)
            {
                AttackItems.Add(_itemFactory.CreateAttackItem());
            }
            else if (worldObject is DefenceItem)
            {
                DefenceItems.Add(_itemFactory.CreateDefenceItem());
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

        public void AddObserver(ICreatureObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ICreatureObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Notify(this);
            }
        }

    }
}
