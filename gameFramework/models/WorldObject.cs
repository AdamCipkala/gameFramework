using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public class WorldObject
    {
        private int X { get; set; }
        private int Y { get; set; }

        private string Name { get; set; }
        private bool Removable { get; set; }
        private bool Lootable { get; set; }
        private Position Position { get; set; }
        private List<AttackItem> AttackItems { get; set; }
        private List<DefenceItem> DefenceItems { get; set; }

    }
}
