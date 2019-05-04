using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Models
{
    /// <summary>
    /// Мой класс для математических действий
    /// </summary>
    public static class MyMath
    {
        /// <summary>
        /// Та величина, которую мы считаем нулевой
        /// </summary>
        public static double Epsilon = 0.001;
        /// <summary>
        /// точность сравнения дробных величин 
        /// </summary>
        public static int Precision = 4;
        /// <summary>
        /// максимальное дефолтное значение для рендома
        /// </summary>
        private static int maxRendomDefault = 1;
        /// <summary>
        /// объект рендома
        /// </summary>
        private static Random rnd = new Random(DateTime.Now.Millisecond);
        /// <summary>
        /// рендом
        /// </summary>
        /// <param name="maxValue">максимальное по модулю значение рендома</param>
        /// <param name="isPositive">рендом - только положительные значения</param>
        /// <returns></returns>
        public static double Rendom(double maxValue = -1, bool isPositive = false)
        {
            double MaxValue = maxValue > 0 ? maxValue : MyMath.maxRendomDefault;
            double d = isPositive ? MyMath.rnd.NextDouble() :  MyMath.rnd.NextDouble() * 2 - 1.0;
            return d * MaxValue;            
        }
        /// <summary>
        /// рендом
        /// </summary>
        /// <param name="maxValue">максимальное по модулю значение рендома</param>
        /// <param name="isPositive">рендом - только положительные значения</param>
        /// <returns></returns>
        public static int Rendom(int maxValue, bool isPositive = false)
        {
            int MaxValue = maxValue > 0 ? maxValue : MyMath.maxRendomDefault;
            return MyMath.rnd.Next(isPositive ? 0 : -1 * MaxValue, MaxValue);
        }
    }
}
