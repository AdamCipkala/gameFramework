using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    /// <summary>
    /// Represents an object that exists within the game world.
    /// </summary>
    public class WorldObject
    {
        /// <summary>
        /// Gets or sets the x-coordinate of the object's position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y-coordinate of the object's position.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the name of the object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the object can be removed from the game world.
        /// </summary>
        public bool Removable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the object can be looted.
        /// </summary>
        public bool Lootable { get; set; }

        /// <summary>
        /// Gets or sets the position of the object.
        /// </summary>
        public Position Position { get; set; }
    }
}
