using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public class World
    {
        public static TraceSwitch traceSwitch = new TraceSwitch("MySwitch", "My switch description");

        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public static List<Creature> Creatures { get; set; }
        public static List<WorldObject> WorldObjects { get; set; }
    }
}
