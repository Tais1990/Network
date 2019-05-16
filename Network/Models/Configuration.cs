using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Models
{
    public class Configuration : BaseVM
    {
        /// <summary>
        /// длина контейнера x
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// ширина контейнера y
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// Частицы 
        /// </summary>
        public Collection<Particle> Particles { get; set; }
        /// <summary>
        /// Пустой конструктор. с дефолтными значениями
        /// TO-DO реализовать разные вариаенты формирования начальной конфигурации
        /// </summary>
        public Configuration()
        {
            this.Length = 50.0;
            this.Width = 50.0;
            this.Particles = new Collection<Particle>();

            this.Particles.Add(new Particle(10, 10, 3, new Vector(10, 0)));
            this.Particles.Add(new Particle(25, 25, 2, new Vector(10, 10)));
            this.Particles.Add(new Particle(40, 25, 4, new Vector(0, 10)));
        }
        /// <summary>
        /// Конструктор по перечню значений
        /// </summary>
        /// <param name="length">длина контейнера x</param>
        /// <param name="width">ширина контейнера y</param>
        /// <param name="particles">Частицы</param>
        public Configuration(double length, double width, Collection<Particle> particles)
        {
            this.Length = length;
            this.Width = width;
            this.Particles = new Collection<Particle>();
            // вот тут меня гложат сомнения, как надо поступить - подставить, как ссылки, или собрать копии
            foreach (Particle particle in particles)
            {
                this.Particles.Add(new Particle(particle));
            }
        }
        /// <summary>
        /// СОздание конфигурации на основании другой конфигурации
        /// </summary>
        /// <param name="configuration"></param>
        public Configuration(Configuration configuration)
        {
            this.Length = configuration.Length;
            this.Width = configuration.Width;
            this.Particles = new Collection<Particle>();
            for (int i = 0; i < configuration.Particles.Count; i++)
            {
                this.Particles.Add(new Particle(configuration.Particles[i]));
            }
        }
        /// <summary>
        /// Передвижение системы на время time
        /// </summary>
        /// <param name="time">время, в течени которого происходит перредвижение системы</param>
        /// <returns></returns>
        public Configuration Move(double time)
        {
            for (int i = 0; i < this.Particles.Count; i++)
            {
                this.Particles[i].Move(time);
                this.Particles[i].CrossWall(this.Length, this.Width);
            }
            //TO-DO проверку на соударение частиц
            return this;
        }
    }
}
