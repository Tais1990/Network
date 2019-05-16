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
        /// Радиус частицы
        /// </summary>
        public double Radius { get; set; }
        /// <summary>
        /// начальная положение частицы
        /// </summary>
        public Point StartPoint { get; set; }
        /// <summary>
        /// коллекция положений частицы
        /// </summary>
        public Collection<Point> Points { get; set; }
                
        /// <summary>
        /// Конструктор, на основании теоретической частицы и коэффициента сопоставления между графической область и теоретической моделью
        /// </summary>
        /// <param name="particle">теоретическая частица</param>
        /// <param name="coefficient">коэффициент сопроставления</param>
        public ParticleGraphic(Particle particle, double coefficient)
        {
            this.Radius = particle.Radius * coefficient;
            this.StartPoint = new Point((particle.X - particle.Radius) * coefficient, (particle.Y - particle.Radius) * coefficient);
            this.Points = new Collection<Point>();
        }
    }
}
