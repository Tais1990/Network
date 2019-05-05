using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Models
{
    class Configuration : BaseVM
    {
        /// <summary>
        /// длина контейнера x
        /// </summary>
        public double length { get; set; }
        /// <summary>
        /// ширина контейнера y
        /// </summary>
        public double width { get; set; }
        /// <summary>
        /// Частицы 
        /// </summary>
        public Collection<Particle> particles { get; set; }
        public int currentTime { get; set; }

        public Configuration()
        {
            this.length = 50.0;
            this.width = 50.0;
            this.particles = new Collection<Particle>();

            this.particles.Add(new Particle(10, 10, 3, new Vector(1, 0)));
        }
    }
}
