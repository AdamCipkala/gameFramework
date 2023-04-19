using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static gameFramework.models.Creature;

namespace gameFramework.models
{
    // Component interface
    public interface ICreatureComponent
    {
        void Hit(Creature target);
        void ReceiveHit(int damage);
        void Pick(WorldObject worldObject);
    }

    public class Creature
    {

        public int Id { get; }
        public string Name { get; set; }
    
        public int HitPoints { get; set; }

        public List<AttackItem> AttackItems { get; set; }
       
        public List<DefenceItem> DefenceItems { get; set; }
      
        public Position Position { get; set; }

        private static readonly TraceSwitch _traceSwitch = new TraceSwitch("CreatureTraceSwitch", "Switch for creature tracing", TraceLevel.Info.ToString());

        private readonly ItemFactory _itemFactory = new NormalItemFactory();

        private readonly List<ICreatureObserver> _observers = new List<ICreatureObserver>();

        private int _activeWeaponIndex;

        public AttackItem ActiveWeapon => AttackItems[_activeWeaponIndex];

        private static int _idCounter = 0; 


        public Creature()
        {
            this.Id = System.Threading.Interlocked.Increment(ref _idCounter);

            HitPoints = 100;
            AttackItems = new List<AttackItem>();
            DefenceItems = new List<DefenceItem>();
            _activeWeaponIndex = 0;
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

        public void SwitchWeapon(int index)
    {
        if (index >= 0 && index < _attackItems.Count)
        {
            _activeWeaponIndex = index;
        }
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

    public class CompositeCreature : ICreatureComponent
    {
        private readonly List<ICreatureComponent> _components = new List<ICreatureComponent>();

        public void AddComponent(ICreatureComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(ICreatureComponent component)
        {
            _components.Remove(component);
        }

        public void Hit(Creature target)
        {
            foreach (var component in _components)
            {
                component.Hit(target);
            }
        }

        public void ReceiveHit(int damage)
        {
            foreach (var component in _components)
            {
                component.ReceiveHit(damage);
            }
        }

        public void Pick(WorldObject worldObject)
        {
            foreach (var component in _components)
            {
                component.Pick(worldObject);
            }
        }
        
    }



}
