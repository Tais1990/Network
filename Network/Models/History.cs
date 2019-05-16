using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Network.Models
{
    public class History: BaseVM
    {
        /// <summary>
        /// колекция конфигурации
        /// </summary>
        public Collection<Configuration> Configurations = new Collection<Configuration>();
        /// <summary>
        /// пустой конструктор
        /// </summary>
        public History()
        {
            Configurations.Add(new Configuration());            
        }
        /// <summary>
        /// Вычисление движения, с указанием в качестве конечной временной точки endTime
        /// </summary>
        /// <param name="endTime">Конечное время</param>
        public void Move(double endTime)
        {
            // настроечная характеристика, фактиечски зависит от скоростей частиц.
            //чем больше скорости, тем меньше она должна быть, чтобы мы не проскакивали соударения
            double timeUnit = 0.1;
            int countStep = (int)(endTime / timeUnit);
            Configuration tmp;
            for (int i = 0; i < countStep; i++)
            {
                tmp = this.Configurations.LastOrDefault();
                Configuration con = new Configuration(tmp);
                Configurations.Add(con.Move(timeUnit));
            }
        }
        /// <summary>
        /// формируем по истории траектории движения конкретной частицы
        /// </summary>
        /// <param name="particleBegin"> частица, для которой выстраиваем движение</param>
        /// <param name="coefficient">коэффициент для отрисовки, сопоставления графической интерритации и теории</param>
        /// <returns></returns>
        public Collection<Point> Path(Particle particleBegin, double coefficient)
        {
            Collection<Point> result = new Collection<Point>();
            int index = this.Configurations.FirstOrDefault<Configuration>().Particles.IndexOf(particleBegin);
            if (index > -1)
            {
                for (int i = 1; i < this.Configurations.Count; i++)
                {
                    Particle particle = this.Configurations[i].Particles[index];
                    result.Add(new Point((particle.X - particle.Radius) * coefficient, (particle.Y - particle.Radius) * coefficient));
                }
            }
            return result;
        }
    }
}
