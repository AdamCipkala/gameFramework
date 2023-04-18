using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public class AttackItem : WorldObject
    {
        public int HitPoints { get; set; }
        public int Range { get; set; }
        public string Description { get; set; }
    }
}
