using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public class World
    {
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        private List<Creature> Creatures { get; set; }
        private List<WorldObject> WorldObjects { get; set; }
    }
}
