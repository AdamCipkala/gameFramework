using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    /// <summary>
    /// Represents an attack item in the game world.
    /// </summary>
    public class AttackItem : WorldObject
    {
        /// <summary>
        /// Gets or sets the number of hit points that this attack item can inflict.
        /// </summary>
        public int HitPoints { get; set; }

        /// <summary>
        /// Gets or sets the range of the attack item.
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Gets or sets a description of the attack item.
        /// </summary>
        public string Description { get; set; }
    }
}
