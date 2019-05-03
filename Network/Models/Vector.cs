using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Models
{
    /// <summary>
    /// Вектор
    /// </summary>
    public class Vector
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
        /// Пустой конструктор
        /// </summary>
        public Vector()
        {
            this.X = MyMath.Rendom(5.0);
            this.Y = MyMath.Rendom(5.0);
        }
        /// <summary>
        /// Конструктор с передаваемыми значениями
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        /// <summary>
        /// Конструктор копия
        /// </summary>
        /// <param name="v"></param>
        public Vector(Vector v)
        {
            this.X = v.X;
            this.Y = v.Y;
        }
        /// <summary>
        /// Вычисление длины вектора
        /// </summary>
        /// <returns></returns>
        public double Mod()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y);
        }
        /// <summary>
        /// Опреатор умножения векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator *(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
        /// <summary>
        /// оператор вычисления углов между векторами
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator ^(Vector a, Vector b)
        {
            // определим для начала знак поворота, через скалярное произведение
            int sign = Math.Sign(a.X * b.Y - a.Y * b.X);
            sign = sign == 0 ? 1 : sign;
            return Math.Acos((a * b) / (a.Mod() * b.Mod())) * sign;
        }
        /// <summary>
        /// Оператор вычитания векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
        /// <summary>
        /// Оператор суммировния векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
        /// <summary>
        /// поворот вектора на указанный угол
        /// </summary>
        /// <param name="angle">угол</param>
        /// <returns></returns>
        public Vector Rotation(double angle)
        {
            return new Vector(Math.Cos(angle) * this.X - Math.Sin(angle) * this.Y, Math.Sin(angle) * this.X + Math.Cos(angle) * this.Y);
        }
    }
}
