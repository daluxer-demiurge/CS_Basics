using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    delegate double Fun(double a, double x);

    class Program
    {
        #region - Task1
        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
               
        public static double Squered(double a, double x)
        {
            return a * (x * x);
        }

        //public static double Sinusided(double a, double x)
        //{
        //    return (a * Math.Sin(x));
        //}


        static void Main(string[] args)
        {
            Console.WriteLine("Таблица функции a * x^2:");
            Table(new Fun(Squered), 2, -2, 2);
            //Console.WriteLine("Таблица функции a * x^2:");
            //Table(delegate (double a, double x) { return (a * (x * x)); }, 2, -2, 2);
            Console.WriteLine("Таблица функции a * sinx");            
            Table(delegate (double a, double x) { return (a * Math.Sin(x)); }, 2, -2, 2);
            Console.ReadKey();
        }
        #endregion
    }

}
