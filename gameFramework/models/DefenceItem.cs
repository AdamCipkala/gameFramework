using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    /// <summary>
    /// Represents a defence item in the game world.
    /// </summary>
    public class DefenceItem : WorldObject
    {
        /// <summary>
        /// Gets or sets the name of the defence item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of hit points that the defence item can reduce from an attack.
        /// </summary>
        public int ReduceHitPoints { get; set; }
    }
}
