using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            #region - Menu
            //MyMenu()
            int taskNo = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите номер задачи. Для завершения работы приложения введите 0." +
                    "\n1.Удвоитель" +
                    "\n2.Угадай число");
                Console.ResetColor();
                taskNo = int.Parse(Console.ReadLine());
                switch (taskNo)
                {
                    case 0:
                        break;
                    //case 1:
                    //    Task1();
                    //    break;
                    //case 2:
                    //    Task2();
                    //    break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Задачи с таким номером не существует! Повторите ввод.");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                }
            }
            while (taskNo != 0);

            #endregion
        }
    }
}
