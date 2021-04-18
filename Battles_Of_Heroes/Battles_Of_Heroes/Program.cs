using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battles_Of_Heroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5; //количество кентавров
            int[] heroes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] battles = new int [n];
            for (int i=0; i<=(n-1); i++)
            {
                battles[i] = heroes[i];
                Console.WriteLine(battles[i]);

            }

            //поиск индекса массива с минимальным значением переменной
            int iMin, z = 0;

            for (int j=0; j<=battles.Length; j++)
            {
                if (battles[z] < battles[j])
                {
                    iMin = z;
                    Console.WriteLine("Новое минимальоне найдено: " + battles[j]);
                    z++;
                }
            }

            Console.ReadKey();



        }
    }
}
