using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson5
{
  

    class Program
    {
        #region - Menu
        public static void MyMenu()
        {
            int taskNo = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите номер задачи. Для завершения работы приложения введите 0." +
                    "\n1.Корректность ввода логина." +
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
                    //case 2:
                    //    Task2();
                    //    break;
                    //case 3:
                    //    Task3();
                    //    break;
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
        #endregion
        #region - MetodsForTask1
        public static bool CheckLogin(string userLogin)
        {
                        
            if (userLogin.Length < 2 || userLogin.Length > 10)
            {
                Console.WriteLine("Логин должен быть от 2 до 10 символов");
                return false;
            }
            else
            {
                char[] login = userLogin.ToCharArray();
                for (int i = 0; i < login.Length; i++)
                {
                    var category = char.GetUnicodeCategory(login[i]);

                    switch (category)
                    {
                        case UnicodeCategory.DecimalDigitNumber:
                            if (i == 0)
                            {
                                Console.WriteLine("Вы не можете использовать цифру в начале логина.");
                                return false;
                            }
                            break;
                        case UnicodeCategory.UppercaseLetter:
                            if ('\u0041' > login[i] && login[i] > '\u005A')
                            {
                                Console.WriteLine("Используйте буквы только латинского алфавита.");
                                return false;
                            }
                            break;
                        case UnicodeCategory.LowercaseLetter:
                            if ('a' > login[i] && login[i] > 'z')
                            {
                                Console.WriteLine("Используйте буквы только латинского алфавита.");
                                return false;
                            }
                            break;
                        default:
                            Console.WriteLine("Повторите ввод логина. Используйте только цифры и буквы латинского языка. Логин не может начинаться с цифры.");
                            return false;                            
                    }                    
                }    
            }
            return true;
        }

        public static bool CheckLoginRegex(string userLogin)
        {
            Regex regex = new Regex(@"^(\D[a-zA-Z0-9]{2,10})");
            return regex.IsMatch(userLogin);
            
        }

        #endregion
        #region - Task1
        public static void Task1()
        {            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 1.");
            Console.WriteLine("Создать программу, которая будет проверять корректность ввода логина."+
                "\nКорректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:"+
                "\nа) без использования регулярных выражений"+
                "\nб) **с использованием регулярных выражений.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            bool loginOk;
            do
            {
                Console.WriteLine("Введите логин."+
                    "\nОт 2 до 10 символов."+
                    "\nВозможно использование латинского алфавита и цифр."+
                    "\nЛогин не может начинаться с цифры."+
                    "\nВведите 'esc' в поле логина для отмены.");
                string userLogin = Console.ReadLine();
                if (userLogin == "esc") break;
                loginOk = CheckLogin(userLogin);
                if (loginOk == true) Console.WriteLine("Введён корректный логин.");
            }
            while (loginOk != true);           
            
            goMenu();
        }
        #endregion
        public static void goMenu()
        {
            Console.WriteLine("Для возврата в Меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            MyMenu();
        }
    }
}
