using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFramework.models
{
    /// <summary>
    /// Represents the game world where creatures and objects exist.
    /// </summary>
    public class World
    {
        /// <summary>
        /// Gets or sets the size of the world along the X-axis.
        /// </summary>
        public int SizeX { get; set; }

        /// <summary>
        /// Gets or sets the size of the world along the Y-axis.
        /// </summary>
        public int SizeY { get; set; }

        /// <summary>
        /// Gets or sets the list of creatures currently present in the world.
        /// </summary>
        public static List<Creature> Creatures { get; set; }

        /// <summary>
        /// Gets or sets the list of objects currently present in the world.
        /// </summary>
        public static List<WorldObject> WorldObjects { get; set; }
    }
}
