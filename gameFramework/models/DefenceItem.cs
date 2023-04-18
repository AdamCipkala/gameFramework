using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    public class DefenceItem : WorldObject
    {
        public string Name { get; set; }
        public int ReduceHitPoints { get; set; }
    }
}
