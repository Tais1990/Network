using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Models
{
    /// <summary>
    /// Частица
    /// </summary>
    public class Particle : BaseVM
    {
        /// <summary>
        /// координата x
        /// </summary>
        public double X;
        /// <summary>
        /// координата y
        /// </summary>
        public double Y;
        /// <summary>
        /// радиус частицы
        /// </summary>
        public double Radius;
        /// <summary>
        /// вестор скорости
        /// </summary>
        public Vector Speed;
        #region Constructor
        /// <summary>
        /// конструктор пустой
        /// </summary>
        public Particle()
        {
            this.X = MyMath.Rendom(isPositive: true);
            this.Y = MyMath.Rendom(isPositive: true);
            this.Radius = MyMath.Rendom(isPositive: true);
            this.Speed = new Vector();
        }
        /// <summary>
        /// конструктор только с координатами
        /// </summary>
        public Particle(double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.Radius = MyMath.Rendom(isPositive: true);
            this.Speed = new Vector();
        }
        /// <summary>
        ///  конструктор с координатами и радиусом
        /// </summary>
        /// <param name="x">x координата</param>
        /// <param name="y">y координата</param>
        /// <param name="r">радиус частицы</param>
        public Particle(double x, double y, double r)
        {
            this.X = x;
            this.Y = y;
            this.Radius = r;
            this.Speed = new Vector();
        }
        /// <summary>
        /// копирование частицы
        /// </summary>
        /// <param name="particle"></param>
        public Particle(Particle particle)
        {
            this.X = particle.X;
            this.Y = particle.Y;
            this.Radius = particle.Radius;
            this.Speed = new Vector(particle.Speed.X, particle.Speed.Y);
        }
        /// <summary>
        /// конструкатор с корлинатами, радиуом, скоростью
        /// </summary>
        /// <param name="x">x координата</param>
        /// <param name="y">y координата</param>
        /// <param name="r">радиус частицы</param>
        /// <param name="speed_x">x координата скорости</param>
        /// <param name="speed_y">y координата скорости</param>
        public Particle(double x, double y, double r, double speed_x, double speed_y)
        {
            this.X = x;
            this.Y = y;
            this.Radius = r;
            this.Speed = new Vector(speed_x, speed_y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">x координата</param>
        /// <param name="y">y координата</param>
        /// <param name="speed_x">x координата скорости</param>
        /// <param name="speed_y">y координата скорости</param>
        public Particle(double x, double y, double speed_x, double speed_y)
        {
            this.X = x;
            this.Y = y;
            this.Radius = 1.0;
            this.Speed = new Vector(speed_x, speed_y);
        }
        /// <summary>
        /// конструктор с координатами и вектором скорости
        /// </summary>
        /// <param name="x">координата x</param>
        /// <param name="y">координата y</param>
        /// <param name="speed">вестор скорости</param>
        public Particle(double x, double y, Vector speed)
        {
            this.X = x;
            this.Y = y;
            this.Radius = MyMath.Rendom(isPositive: true);
            this.Speed = new Vector(speed.X, speed.Y);
        }
        /// <summary>
        /// конструктор с координатами и вектором скорости
        /// </summary>
        /// <param name="x">координата x</param>
        /// <param name="y">координата y</param>
        /// <param name="r">радиус</param>
        /// <param name="speed">вестор скорости</param>
        public Particle(double x, double y, double r, Vector speed)
        {
            this.X = x;
            this.Y = y;
            this.Radius = r;
            this.Speed = new Vector(speed.X, speed.Y);
        }
        #endregion
        #region Operators
        /// <summary>
        /// Вектор соединяющий частицу b с частицей a
        /// </summary>
        /// <param name="a">первая частица</param>
        /// <param name="b">вторая частица</param>
        /// <returns></returns>
        public static Vector operator -(Particle a, Particle b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
        #endregion
        #region Function
        /// <summary>
        /// Расстояние между частицами a и b
        /// </summary>
        /// <param name="a">первая частица</param>
        /// <param name="b">вторая частица</param>
        /// <returns></returns>
        public static double Distance(Particle a, Particle b)
        {
            return (a - b).Mod();
        }
        /// <summary>
        /// Функция вычисления пересекаются частицы или нет
        /// </summary>
        /// <param name="a">первая частица</param>
        /// <param name="b">вторая частица</param>
        /// <returns></returns>
        public static bool CrossСut(Particle a, Particle b)
        {
            return Distance(a, b) < a.Radius + b.Radius + MyMath.Epsilon;
        }
        /// <summary>
        /// соударение со стенкой
        /// </summary>
        /// <param name="length">длина контейнера</param>
        /// <param name="width">ширина контейнера</param>
        /// <param name="epsilon">условный ноль</param>
        /// <returns></returns>
        public Particle CrossWall(double length, double width)
        {
            if ((this.X - this.Radius < MyMath.Epsilon && this.Speed.X < 0) ||
                (length - this.X - this.Radius < MyMath.Epsilon && this.Speed.X > 0))
                this.Speed.X = -this.Speed.X;
            if ((this.Y - this.Radius < MyMath.Epsilon && this.Speed.Y < 0) ||
                (width - this.Y - this.Radius < MyMath.Epsilon && this.Speed.Y > 0))
                this.Speed.Y = -this.Speed.Y;
            return this;
        }
        /// <summary>
        /// Прямолинейное поступательное равномерное движение чстицы
        /// </summary>
        /// <param name="time">время в течении которого частица двигалась</param>
        /// <returns></returns>
        public Particle Move(double time)
        {
            this.X = this.X + this.Speed.X * time;
            this.Y = this.Y + this.Speed.Y * time;
            return this;
        }
        #endregion
        #region Assistive
        /// <summary>
        /// Логгер
        /// </summary>
        /// <param name="logger"></param>
        public void toLog(Logger logger)
        {
            logger.Debug(string.Format(@"Координаты : {0} {1}; Скорость : {2} {3}", this.X, this.Y, this.Speed.X, this.Speed.Y));
        }
        #endregion
    }
}
