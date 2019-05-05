using Network.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Network.Views
{
    /// <summary>
    /// класс для отображения частицы на области и для анимации её движения
    /// </summary>
    public class ParticleGraphic: BaseVM
    {
        /// <summary>
        /// теоретическая модель частицы
        /// </summary>
        //public Particle model { get; set; }
        /// <summary>
        /// начальная положение частицы
        /// </summary>
        public Point StartPoint { get; set; }
        /// <summary>
        /// коллекция положений частицы
        /// </summary>
        public Collection<Point> Points { get; set; }

        public double Radius { get; set; }

        public ParticleGraphic(Particle particle, double coefficient)
        {
            //this.model = particle;
            this.Radius = particle.Radius * coefficient;
            this.StartPoint = new Point((particle.X - particle.Radius) * coefficient, (particle.Y - particle.Radius) * coefficient);
            this.Points = new Collection<Point>();
            // случайное движение
            this.Points.Add(new Point(10, 10));
            this.Points.Add(new Point(250, 250));
            this.Points.Add(new Point(250, 10));
            this.Points.Add(new Point(10, 250));


        }
    }
}
