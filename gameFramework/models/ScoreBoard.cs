using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    // Component interface
    public interface ICreature
    {
        void Hit(Creature target);
        void ReceiveHit(int damage);
        void Pick(WorldObject worldObject);
    }
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
}
