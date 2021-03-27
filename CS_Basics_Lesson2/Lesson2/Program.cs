using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        #region - Task1
        public static void Task1()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 1.");
            Console.WriteLine("Написать метод, возвращающий минимальное из трех чисел.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor(); 
            Console.WriteLine();
            Console.WriteLine("Введите три целых числа. \nПосле ввода каждого числа подтверждайте ввод клавишей Enter.");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int min = FindMin(a, b, c);
            Console.WriteLine("Минимальное из введеных Вами трёх чисел: " + min);
            goMenu();
        }
        public static int FindMin(int a, int b, int c)
        {
            int min;
            if (a < b && a < c)
            {
                min = a;
            }
            else if (b < c)
            {
                min = b;
            }
            else min = c;
            return min;
        }
        #endregion
        #region - Task2
        public static void Task2()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 2.");
            Console.WriteLine("Написать метод подсчета количества цифр числа.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Введите целое число\n(не более 18 цифр).");
            long num = long.Parse(Console.ReadLine());
            long simbCount = NumberOfDigits(ref num);
            Console.WriteLine(string.Format("Количество цифр вашего числа: " + simbCount));
            goMenu();


        }

        public static long NumberOfDigits(ref long num)
        {
            long simbCount = 0;
            while (num > 0)
            {
                num = num / 10;
                simbCount++;
            }
            return simbCount;
        }
        #endregion
        #region - Task3
        public static void Task3()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 3.");
            Console.WriteLine("С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Вводите числа.\n" +
                "Программа подсчитает сумму всех введёных Вами нечётных положительных чисел.\n" +
                "Введите 0 для окончания ввода чисел.");
            long number, sumNumber = 0;
            do
            {
                Console.WriteLine("Ведите число");
                number = long.Parse(Console.ReadLine());
                if (number % 2 != 0)
                {
                    sumNumber = sumNumber + number;
                }
            } while (number != 0);
            Console.WriteLine(string.Format("Сумма введённых Вами нечётных положительных чисел равна:" + sumNumber));
            goMenu();
        }
        #endregion
        #region - Task4
        public static void Task4()
        {
            Console.Clear();
            Console.WriteLine("ЗАДАНИЕ 4.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Реализовать метод проверки логина и пароля. \n" +
                "На вход подается логин и пароль. \n" +
                "На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). \n" +
                "Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. \n" +
                "С помощью цикла do while ограничить ввод пароля тремя попытками.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();                     
            int tryCount = 0;
            int maxTryCount = 3;
            string login = "root";
            string pass = "GeekBrains";

            do
            {
                Console.WriteLine("Введите логин");
                string userLogin = Console.ReadLine();
                Console.WriteLine("Введите пароль");
                string userPass = Console.ReadLine();
                if (userLogin == login && userPass == pass)
                {
                    Console.WriteLine("Аторизация пройдена успешно.");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный логин и/или пароль.");
                    tryCount++;
                }
            } while (tryCount < maxTryCount);
            goMenu();
        }
        #endregion
        #region - Task5
        public static void Task5()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 5.");
            Console.WriteLine("Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме. \n " +
                "*Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            double imt = 0;
            Console.WriteLine("Введите вес в килограммах. Можете использовать запятую, если число не целое.");
            double m = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост в метрах. Можете использовать запятую, если число не целое.");
            double h = double.Parse(Console.ReadLine());
            imt = m / (h * h);
            double OKmin = 18.5 * (h * h);
            double OKmax = 25 * (h * h);
            double resultMax = OKmin - m;
            double resultMin = OKmax - m;

            #region - Почему нельзя так?
            //switch (imt)
            //{
            //    case <= 16:
            //        Console.WriteLine("У Вас выраженный дефицит массы тела");
            //        imtPrintLow();
            //        break;
            //    case < 18.5:
            //        Console.WriteLine("У Вас недостаточная масса тела");
            //        imtPrintLow();
            //        break;
            //    case < 25:
            //        Console.WriteLine("У Вас норма, старайтесь держаться этого веса.");                    
            //        break;
            //    case < 35:
            //        Console.WriteLine("У Вас ожирение");
            //        imtPrintHi();
            //        break;
            //    case < 40:
            //        Console.WriteLine("У Вас ожирение");
            //        imtPrintHi();
            //        break;
            //    case >= 40:
            //        Console.WriteLine("У Вас ожирение");
            //        imtPrintHi();
            //        break;
            //}
            #endregion

            if (imt <= 16)
            {
                Console.WriteLine("У Вас выраженный дефицит массы тела");
                Console.WriteLine("Наберите от {0:F2} до {1:F2} кг веса", resultMin, resultMax);
            }
            else if (imt < 18.5)
            {
                Console.WriteLine("У Вас недостаточная масса тела");
                Console.WriteLine("Наберите от {0:F2} до {1:F2} кг веса", resultMin, resultMax);
            }
            else if (imt < 25)
            {
                Console.WriteLine("У Вас норма, старайтесь держаться этого веса.");
            }
            else if (imt < 35)
            {
                Console.WriteLine("У Вас ожирение");
                Console.WriteLine("Нужно скинуть от {0:F2} до {1:F2} кг веса", resultMin, resultMax);
            }
            else if (imt < 40)
            {
                Console.WriteLine("У Вас резкое ожирение");
                Console.WriteLine("Нужно скинуть от {0:F2} до {1:F2} кг веса", resultMin, resultMax);
            }
            else if (imt >= 40)
            {
                Console.WriteLine("У Вас очень резкое ожирение");
                Console.WriteLine("Нужно скинуть от {0:F2} до {1:F2} кг веса", resultMin, resultMax);
            }
            goMenu();
        }

        public static void imtPrintLow(double resultMin, double resultMax)
        {
            double min = resultMin;
            double max = resultMax;
            Console.WriteLine("Нужно набрать от {0:F2} до {1:F2} кг веса", min, max);
        }

        public static void imtPrintHi(double resultMin, double resultMax)
        {
            double min = resultMin;
            double max = resultMax;
            Console.WriteLine("Нужно скинуть от {0:F2} до {1:F2} кг веса", min, max);
        }
        #endregion
        #region - Task6
        public static void Task6()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 6.");
            Console.WriteLine("*Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000. \n" +
                "Хорошим называется число, которое делится на сумму своих цифр. \n" +
                "Реализовать подсчет времени выполнения программы, используя структуру DateTime.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Запаситесь терпением, решение данной задачи - магия чистой воды... потребуется время...");
            int numberMin = 1;
            int numberMax = 1000000000;
            int goodNumbers = 0, countNumbers = 0;

            DateTime start = DateTime.Now;
            for (int i = numberMin; i < numberMax; i++)
            {
                countNumbers = calculateNumbers(i);
                if ((i % countNumbers) == 0)
                    goodNumbers++;
            }
            Console.Write("Количество чисел, которые делятся на сумму своих цифр в интервале от 1 до 1 000 000 000");
            Console.WriteLine(" составило {0:N0} штук", goodNumbers);
            DateTime finish = DateTime.Now;
            Console.Write("Время выполнения программы: ");
            Console.WriteLine(finish - start);
            goMenu();
        }

        public static int calculateNumbers(int i)
        {
            int count = 0;
            while (i > 0)
            {
                i = i / 10;
                count++;
            }
            return count;
        }
        #endregion
        #region - Task7
        public static void Task7()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 7.");
            Console.WriteLine("Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b). \n" +
                "*Разработать рекурсивный метод, который считает сумму чисел от a до b.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Введите первое число");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите последнее число");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Последовательность чисел: ");
            Loop(a, b);
            Console.WriteLine("Сумма чисел: " + Sum(a, b));
            goMenu();
        }

        public static void Loop(int c, int d)
        {
            Console.Write("{0,3} ", c);
            if (c < d) Loop(c + 1, d);
        }

        public static int Sum(int c, int d)
        {
            if (c > d) return 0;
            return c + Sum(c + 1, d);
        }
        #endregion

        public static void goMenu()
        {
            Console.WriteLine("Для возврата в Меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            int taskNo = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите номер задачи. Для завершения работы приложения введите 0.");
                Console.WriteLine("1.Метод, возвращающий минимальное из трёх чисел.");
                Console.WriteLine("2.Метод подсчета количества цифр числа.");
                Console.WriteLine("3.Сумму всех нечетных положительных чисел.");
                Console.WriteLine("4.Метод проверки логина и пароля.");
                Console.WriteLine("5.Программа 'Индекс массы тела'");
                Console.WriteLine("6.Программа подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.");
                Console.WriteLine("7.Рекурсивный метод.");
                Console.ResetColor();
                taskNo = int.Parse(Console.ReadLine());
                switch (taskNo)
                {
                    case 0:
                        break;                        
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    case 6:
                        Task6();
                        break;
                    case 7:
                        Task7();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Задачи с таким номером не существует! Повторите ввод.");
                        Console.ResetColor();
                        break;

                }






            }
            while (taskNo != 0);
        }
    }
}
