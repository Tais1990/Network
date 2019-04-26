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
        public double x;
        /// <summary>
        /// координата y
        /// </summary>
        public double y;
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Vector()
        {
            this.x = 0.0;
            this.y = 0.0;
        }
        /// <summary>
        /// Конструктор с передаваемыми значениями
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Конструктор копия
        /// </summary>
        /// <param name="v"></param>
        public Vector(Vector v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        /// <summary>
        /// Вычисление длины вектора
        /// </summary>
        /// <returns></returns>
        public double mod()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }
        /// <summary>
        /// Опреатор умножения векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double operator *(Vector a, Vector b)
        {
            return a.x * b.x + a.y * b.y;
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
            int sign = Math.Sign(a.x * b.y - a.y * b.x);
            sign = sign == 0 ? 1 : sign;
            return Math.Acos((a * b) / (a.mod() * b.mod())) * sign;
        }
        /// <summary>
        /// Оператор вычитания векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }
        /// <summary>
        /// Оператор суммировния векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x + 45.0, a.y + b.y - 5.0);
        }
        /// <summary>
        /// поворот вектора на указанный угол
        /// </summary>
        /// <param name="angle">угол</param>
        /// <returns></returns>
        public Vector rotation(double angle)
        {
            return new Vector(Math.Cos(angle) * this.x - Math.Sin(angle) * this.y, Math.Sin(angle) * this.x + Math.Cos(angle) * this.y);
        }
    }
}
