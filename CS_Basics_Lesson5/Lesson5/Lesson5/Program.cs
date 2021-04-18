using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Lesson5
{
  

    class Program
    {
        public static void goMenu()
        {
            Console.WriteLine("Для возврата в Меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            MyMenu();
        }

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
                    "\n2.Cтатический класс Message для анализа текста.");
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
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Задачи с таким номером не существует! Повторите ввод.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            }
            while (taskNo != 0);
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

        #region - Task2
        public static void Task2()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЗАДАНИЕ 2.");
            Console.WriteLine("Разработать статический класс Message, содержащий следующие статические методы для обработки текста:" +
                "\nа) Вывести только те слова сообщения, которые содержат не более n букв." +
                "\nб) Удалить из сообщения все слова, которые заканчиваются на заданный символ." +
                "\nв) Найти самое длинное слово сообщения." +
                "\nг) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения." +
                "\nд) ***Создать метод, который производит частотный анализ текста." +
                "\nВ качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст." +
                "\nЗдесь требуется использовать класс Dictionary.");
            Console.WriteLine("Автор - Сержов Михаил");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Введите текст для анализа.");
            string analyzedText = Console.ReadLine();
            
            int wayNo, n = 0;
            do
            {
                Console.WriteLine("\nВыберите способ анализа текста. Для возврата в предыдущее меню введите 0." +
                    "\n1.Вывести только те слова текста, которые содержат не более n букв." +
                    "\n2.Удалить из текста все слова, которые заканчиваются на заданный символ." +
                    "\n3.Найти самое длинное слово в тексте." +
                    "\n4.Сформировать строку из самых длинных слов текста.");
                wayNo = int.Parse(Console.ReadLine());
                switch (wayNo)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Введите количество букв в слове (цифрами) для отбора.");
                        n = int.Parse(Console.ReadLine());
                        Message.PrintWord(analyzedText, n);
                        break;
                    case 2:
                        Console.WriteLine("Введите символ. Слова, которые заканчиваются на него, будут удалены из текста.");
                        char labelToDelete = char.Parse(Console.ReadLine());
                        Message.PrintWord(analyzedText, labelToDelete);
                        break;
                    case 3:
                        Console.Write("Самое длинное слово в тексте:");
                        Console.WriteLine(Message.LongestWord(analyzedText));
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Строка из самых длинных слов:");
                        Console.WriteLine(Message.LongestWordsText(analyzedText));
                        Console.ReadLine();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Способа с таким номером не существует! Повторите ввод.");
                        Console.ResetColor();
                        break;
                }
            }
            
            while (wayNo != 0);
        }


              
    }

    public static class Message
    {
        private static string[] separators = { ",", ".", "!", "?", ";", ":", " ", "-", "(", ")", "\"" };
        private static string[] onlySpace = { " " };
        public static void PrintWord(string analyzedText, int n)
        {
            var words = analyzedText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i=0; i< words.Length; i++)
            {
                if (words[i].Length <= n) Console.Write(words[i] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine(analyzedText);

        }

        public static void PrintWord(string analyzedText, char labelToDelete)
        {
            var words = analyzedText.Split(onlySpace, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (labelToDelete != (words[i][words[i].Length - 1])) Console.Write(words[i] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine(analyzedText);

        }

        public static string LongestWord(string analyzedText)
        {
            var words = analyzedText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int temp = 0;
            for (int i = 0; i < words.Length-1; i++)
            {
                if (words[i].Length > words[i++].Length) temp=i;
            }
            return words[temp];
        }

        public static string LongestWordsText(string analyzedText)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var words = analyzedText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int temp = 0;
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words[i].Length > words[i++].Length) temp = i;
            }
            for (int j=0; j < words.Length; j++)
            {
                if (words[j].Length == words[temp].Length && words[j] != (words[temp])) stringBuilder.Append(words[j]);
            }
            stringBuilder.Insert(0, words[temp]);
            return (stringBuilder.ToString());

        }

       

    }

    #endregion

}
