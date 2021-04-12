using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    struct Account
    {
        public string login;
        public string pass;

        public static string[] ReadStringFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                var size = int.Parse(reader.ReadLine());
                var logPass = new string[size];
                for (int i = 0; i < size; i++)
                    logPass[i] = reader.ReadLine();
                reader.Close();
                return logPass;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public string getLogin()
        {
            return login;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int taskNo = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите номер задачи. Для завершения работы приложения введите 0." +
                    "\n1.Пары элементов массива." +
                    "\n2.Класс работы с одномерным массивом." +
                    "\n3.Логины и пароли." +
                    "\n4.Класс работы с двумерным массивом.");
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
                    //case 4:
                    //    Task4();
                    //    break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Задачи с таким номером не существует! Повторите ввод.");
                        Console.ResetColor();
                        break;
                }
            }
            while (taskNo != 0);
        }
        #region - Task1
        public static void Task1()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 1.");
            Console.WriteLine("Дан целочисленный массив из 20 элементов." +
                "\nЭлементы массива могут принимать целые значения от –10 000 до 10 000 включительно." +
                "\nНаписать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3." +
                "\nВ данной задаче под парой подразумевается два подряд идущих элемента массива." +
                "\nНапример, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            int[] array = new int[20];
            int min = -10000;
            int max = 10000;
            int count = 0;
            Console.WriteLine("Массив случайно заданных чисел: ");

            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(min, max);
                Console.Write(array[i] + " ");
            }

            for (int j = 0; j < array.Length - 1; j++)
                if ((array[j] % 3) == 0 || (array[j + 1] % 3) == 0) count++;
            Console.WriteLine();
            Console.WriteLine("\nКоличество пар элементов массива, в которых хотя бы одно число делится на 3: " + count);
            goMenu();
        }
        #endregion
        public static void goMenu()
        {
            Console.WriteLine("\nДля возврата в Меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        #region - Task3
        public static void Task3()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 3.");
            Console.WriteLine("Реализовать метод проверки логина и пароля." +
                "\nНа вход метода подается логин и пароль." +
                "\nНа выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains, логины и пароли считать из файла в массив)." +
                "\nИспользуя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает." +
                "\nСоздать структуру Account, содержащую Login и Password." +
                "\nС помощью цикла do while ограничить ввод пароля тремя попытками.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            int tryCount = 0;
            int maxTryCount = 3;
            
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

        #region - Task2
        public static void Task2()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 2.");
            string text = "массив заданной размерности (10) и заполняющий массив числами от начального значения (1) с заданным шагом (2).";
            string text1 = "\nсвойство Sum, которое возвращает сумму элементов массива;";
            string text2 = "\nметод Inverse, меняющий знаки у всех элементов массива;";
            string text3 = "\nметод Multi, умножающий каждый элемент массива на определенное число;";
            string text4 = "\nсвойство MaxCount, возвращающее количество максимальных элементов.";
            Console.WriteLine("а) Дописать класс для работы с одномерным массивом." + "\nРеализовать конструктор, создающий " + text +
                "\nСоздать:" + text1 + text2 + text3 + text4 +
                "\nПродемонстрировать работу класса." +
                "\nб)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            var arr1 = MyArray.ReadFromFile(AppDomain.CurrentDomain.BaseDirectory + "ArrayData.txt");
            Console.WriteLine("Массив, выгруженный из файла ArrayData.txt: ");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i] + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("Демонстрация работы класса MyArray:");
            MyArray myArray1 = new MyArray(10, 1, 2);
            MyArray showClass1 = myArray1;
            Console.WriteLine(text);
            Console.WriteLine(showClass1.ArrayToString());
            Console.WriteLine(text1 + "\n" + showClass1.Sum);
            Console.WriteLine(text2 + "\n" + showClass1.Inverse);
            Console.WriteLine(text3 + "\n" + showClass1.Multi(10));
            //Console.WriteLine(text4 + "\n" + showClass1.MaxCount);
            Console.WriteLine();
            goMenu();
            Console.WriteLine("Записать массив в ArrayData.New.txt перед выходом в Меню?" +
                "\nНажмите Enter для подтверждения, нажмите любую другую клавишу для выхода без сохранения.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                MyArray.WriteToFile(arr1, AppDomain.CurrentDomain.BaseDirectory + "ArrayData.New.txt");
            }
            else
            {
                Console.WriteLine();
            }

        }

    }
    public class MyArray
    {
        int[] a;

        //  Создание массива заданной размерности и заполнение его числами от начального значения с заданным шагом
        public MyArray(int n, int min, int step)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = min;
                min = min + step;
            }
            //return a;
        }

        public string ArrayToString()
        {
            string str = "";
            for (int i = 0; i < a.Length; i++) str += a[i] + " ";
            return str;
        }


        //свойство Sum, которое возвращает сумму элементов массива
        public int Sum
        {
            get

            {
                int sum = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    sum += a[i];
                }
                return sum;
            }
        }

        //метод Inverse, меняющий знаки у всех элементов массива
        public int[] Inverse
        {
            get
            {

                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = -a[i];
                }
                return a;
            }
        }

        //метод Multi, умножающий каждый элемент массива на определенное число
        public int[] Multi(int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = a[i] * x;
            }
            return a;
        }

        //свойство MaxCount, возвращающее количество максимальных элементов
        public int MaxCount
        {
            get
            {
                int max = 0;
                int maxCount = 0;
                for (int q = 1; q < a.Length; q++) if (a[q] > max) max = a[q];
                //int maxCount = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] == max) maxCount++;
                return MaxCount;
            }
        }


        //
        public static int[] ReadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                var size = int.Parse(reader.ReadLine());
                var arr = new int[size];
                for (int i = 0; i < size; i++)
                {
                    if (int.TryParse(reader.ReadLine(), out int num))
                        arr[i] = num;
                }
                reader.Close();
                return arr;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static void WriteToFile(int[] arr, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                writer.WriteLine(arr[i]);
            }
            writer.Close();
        }
    }
}
    #endregion


