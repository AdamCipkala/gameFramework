using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public class World
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public List<Creature> Creatures { get; set; }
        public List<WorldObject> WorldObjects { get; set; }
    }
}
