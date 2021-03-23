using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Урок 1.Введение.Базовые типы данных.Консоль.Классы и методы.

namespace Task1
{
   
        

class Program
    {
        static void Main(string[] args)
        {
            #region - Задание 1.
            //Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
            //В результате вся информация выводится в одну строчку.
            //а) используя склеивание;
            //б) используя форматированный вывод;
            //в) *используя вывод со знаком $.

            Console.Title = "Анкета";
            string FName, LName;
            int Age, Hight, Wight;

            //ввод данных
            Console.WriteLine("Введите имя");
            FName = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            LName = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост в сантиметрах");
            Hight = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите вес в килограммах");
            Wight = int.Parse(Console.ReadLine());

            //Решение а)
            Console.WriteLine(Convert.ToString("Вывод на экран склейкой --> " + "Имя: " + FName + ", Фамилия: " + LName + ", Возраст: " + Age + ", Рост: " + Hight + ", Вес: " + Wight));
            Console.ReadLine();
            //Решение б)
            Console.WriteLine("Вывод на экран форматированным способом --> " + "{0} " + "{1}, " + "{2}, " + "{3}, " + "{4}.", FName, LName, Age, Hight, Wight);
            Console.ReadLine();
            //Решение в)
            Console.WriteLine("Вывод на экран используя вывод со знаком $ --> " + $"Имя: {FName}, " + $"Фамилия: {LName}, " + $"Возраст: {Age}, " + $"Рост: {Hight}, " + $"Вес: {Wight}");
            Console.ReadLine();
            #endregion

            #region - Задание 2.
            //Ввести вес и рост человека.
            //Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах
            Console.Clear();
            double m, h, I;
            Console.WriteLine("Введите вес в килограммах. Целую часть отделите запятой.");
            m = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост в метрах. Целую часть отделите запятой.");
            h = double.Parse(Console.ReadLine());
            I = m / (h * h);
            Console.WriteLine($"Ваш индекс массы тела: {I:F}");
            Console.ReadLine();
            #endregion

            #region - Задание 3.
            //а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2, y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2 - y1, 2).
            //Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
            //б) *Выполните предыдущее задание, оформив вычисления расстояния между точками в виде метода;
            //Решение а)
            Console.Clear();
            double x1, x2, y1, y2, r;
            Console.WriteLine("Введите координаты х1 для первой точки");
            x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координаты y1 для первой точки");
            y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координаты х2 для второй точки");
            x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координаты y2 для второй точки");
            y2 = double.Parse(Console.ReadLine());
            r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine($"Расстояние между точками равно {r:F2}");
            Console.ReadLine();
            //Решение б)
            Distance(x1, y1, x2, y2);
            #endregion

            #region - Задание 4. 
            //Написать программу обмена значениями двух переменных.
            //а) с использованием третьей переменной;
            //б) *без использования третьей переменной.
            //Решение а)
            Console.Clear();
            int a, b, c = 0;
            Console.WriteLine("Введите значение первой переменной a:");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение второй переменной b:");
            b = int.Parse(Console.ReadLine());
            c = a;
            a = b;
            b = c;
            Console.WriteLine(string.Format("После обмена переменные имеют следующие значения: " + "a=" + a + ", " + "b=" + b));
            //Решение б)
            Console.WriteLine("\n" + "Решение б)");
            Console.WriteLine("Введите значение первой переменной x:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение второй переменной y:");
            int y = int.Parse(Console.ReadLine());
            x = x + y;
            y = x - y;
            x = x - y;
            Console.Write(string.Format("После обмена переменные имеют следующие значения: " + "x=" + x + ", " + "y=" + y));
            helpingProg.Pause(2000);
            #endregion

            #region - Задание 5.
            //а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            //б) Сделать задание, только вывод организуйте в центре экрана
            //в) *Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y)

            //Решение а)
            Console.Clear();
            Console.WriteLine("Михаил Сержов, Самара");
            helpingProg.Pause(0); //использование метода из Задания 6.
            //Решение б)
            Console.WriteLine("А теперь тоже самое, но по центру экрана!");
            helpingProg.Pause(2000);
            Console.Clear();
            string text = "Михаил Сержов, Самара";
            int coordX = (Console.WindowWidth / 2) - (text.Length / 2);
            int coordY = (Console.WindowHeight / 2) - 1;
            Console.SetCursorPosition(coordX, coordY);
            Console.WriteLine(text);
            helpingProg.Pause(0);
            //Решение в
            Console.Clear();
            helpingProg.Print(text);
            helpingProg.Pause(0);
            #endregion

        }

       
        public static void Distance(double x1, double y1, double x2, double y2)
            //метод к Заданию 3(б) сделан быстрым извлечением метода
        {
            double d = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine(d);
        }

    }


    #region - Задание 6.
            //*Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
public class helpingProg
    {
        public static void Pause(int t)
        {
            if (t > 0)
            {
                System.Threading.Thread.Sleep(t);
                    }
            else
            {
                Console.WriteLine("Для продолжения нажмите любую клавишу.");
                Console.ReadKey();
            }
        }

        public static void Print(string text)//метод к Заданию 5(в)
        {
            int coordX = (Console.WindowWidth / 10) - (text.Length / 2);
            int coordY = (Console.WindowHeight / 10) - 1;
            Console.SetCursorPosition(coordX, coordY);
            Console.WriteLine(text);
            System.Threading.Thread.Sleep(1000);
            coordX = (Console.WindowWidth / 2) - (text.Length / 2);
            coordY = (Console.WindowHeight / 2) - 1;
            Console.SetCursorPosition(coordX, coordY);
            Console.WriteLine(text);
            System.Threading.Thread.Sleep(1000);
            coordX = ((Console.WindowWidth / 10)*9) - (text.Length / 2);
            coordY = ((Console.WindowHeight / 10)*9) - 1;
            Console.SetCursorPosition(coordX, coordY);
            Console.WriteLine(text);                       

        }


    }
    #endregion
}
