using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    struct Complex
    {
        #region - Task1

        public double im;
        public double re;
        public Complex Plus(Complex x2)
        {
            Complex x3 = new Complex();
            x3.im = x2.im + this.im;     //В методичке неправильно! для суммы не критично расположение слагаемых, но в вычитании подобная расстановка даст ошибку.
            x3.re = this.re + x2.re;     //Правильно вот так: сначала часть вне метода, потом внутриметодовая часть.
            return x3;
        }
        
        public Complex Multi(Complex x2)//Метод произведения двух комплексных чисел
        {
            Complex x3 = new Complex();
            x3.re = this.re * x2.re - this.im * x2.im;
            x3.im = this.re * x2.im + this.im * x2.re;
            return x3;
        }
        
        public Complex Minus(Complex x2)//Метод вычитания двух комплексных чисел
        {
            Complex x3 = new Complex();
            x3.im = this.im - x2.im;
            x3.re = this.re - x2.re;
            return x3;

        }

        public string ToString()
        {
            if (im < 0) return re + "-" + (-im) + "i;";
            else return re + "+" + im + "i";
        }
        class Fraction
        {
            public int Num;
            public int Denom;


            public Fraction Plus(Fraction x)
            {
                Fraction z = new Fraction();
                z.Denom = this.Denom * x.Denom;
                z.Num = this.Num * x.Denom + x.Num * this.Denom;
                return z;
            }

            public Fraction Minus(Fraction x)
            {
                Fraction z = new Fraction();
                z.Denom = this.Denom * x.Num;
                z.Num = this.Num * x.Denom;
                return z;
            }

            public Fraction Multi(Fraction x)
            {
                Fraction z = new Fraction();
                z.Denom = this.Denom * x.Denom;
                z.Num = this.Num * x.Num;
                return z;
            }

            public Fraction Division(Fraction x)
            {
                Fraction z = new Fraction();
                z.Denom = this.Denom * x.Num;
                z.Num = this.Num * x.Denom;
                return z;
            }

            public string ToString()
            {
                return Num + "/" + Denom;
            }
        }
        class Program
        {
            public static void Task1()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ЗАДАНИЕ 1.");
                Console.WriteLine("а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры." +
                    "\nб) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса." +
                    "\nв) Добавить диалог с использованием switch демонстрирующий работу класса.");
                Console.WriteLine("Автор - Сержов Михаил");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Введите реальные и мнимые части комплексного числа." +
                    "\nПосле ввода каждого числа подтверждайте ввод клавишей Enter.");
                Complex complex1 = new Complex();
                complex1.re = int.Parse(Console.ReadLine());
                complex1.im = int.Parse(Console.ReadLine());
                Complex complex2 = new Complex();
                complex2.re = int.Parse(Console.ReadLine());
                complex2.im = int.Parse(Console.ReadLine());
                Complex result = complex1.Plus(complex2);
                Console.WriteLine("Сумма заданных комплексных чисел: " + result.ToString());
                result = complex1.Minus(complex2);
                Console.WriteLine("Разность заданных комплексных чисел: " + result.ToString());
                result = complex1.Multi(complex2);
                Console.WriteLine("Результат умножения заданных комплексных чисел: " + result.ToString());
                //Console.ReadKey();
                goMenu();
            }
            #endregion

            #region - Task2
            public static void Task2()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ЗАДАНИЕ 2.");
                Console.WriteLine("а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке)." +
                    "\nТребуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse" + 
                    "\nб) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные." +
                    "\nПри возникновении ошибки вывести сообщение.Напишите соответствующую функцию;");
                //Задание б) удалено ГБ, но чем больше кода, тем выше скилл)))
                Console.WriteLine("Автор - Сержов Михаил");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Вводите числа." + 
                    "\nПрограмма подсчитает сумму всех введёных Вами нечётных положительных чисел." +
                    "\nВведите 0 для окончания ввода чисел.");
                int number, sum = default;
                string totalLine = default;
                do
                {
                    Console.WriteLine("Введите число");
                    string input = Console.ReadLine();
                    bool result = Int32.TryParse(input, out number);

                    if (number > 0 && number % 2 != 0)
                    {
                        totalLine = totalLine + ", " + input;
                        sum = sum + number;
                    }
                    else if (result == false || number < 0) number = ErrorInput(number);
                } while (number != 0);
                Console.WriteLine(string.Format("Сумма нечётных положительных чисел" + totalLine + " равна " + sum));
                goMenu();
            }
            public static int ErrorInput(int number)
            {
                Console.WriteLine("Неправильный ввод, повторите.");
                number = 1; //для предотвращения выхода по while !=0 
                return number;
            }
            #endregion

            #region - Task3
            public static void Task3()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ЗАДАНИЕ 3.");
                Console.WriteLine("*Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел." +
                    "\nПредусмотреть методы сложения, вычитания, умножения и деления дробей." +
                    "\nНаписать программу, демонстрирующую все разработанные элементы класса." +
                    "\nДобавить свойства типа int для доступа к числителю и знаменателю." +
                    "\nДобавить свойство типа double только на чтение, чтобы получить десятичную дробь числа." +
                    "\n**Добавить проверку, чтобы знаменатель не равнялся 0.Выбрасывать исключение ArgumentException('Знаменатель не может быть равен 0')." +
                    "\n***Добавить упрощение дробей.");
                Console.WriteLine("Автор - Сержов Михаил");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Вводите числа." +
                    "\nСначала числитель и знаменатель первой дроби." +
                    "\nЗатем, числитель и знаменатель второй дроби.");
                Fraction FractNumber1 = new Fraction();
                FractNumber1.Num = int.Parse(Console.ReadLine());
                FractNumber1.Denom = int.Parse(Console.ReadLine());
                Fraction FractNumber2 = new Fraction();
                FractNumber2.Num = int.Parse(Console.ReadLine());
                FractNumber2.Denom = int.Parse(Console.ReadLine());
                try
                {
                    int res1 = FractNumber1.Num / FractNumber1.Denom;
                    int res2 = FractNumber2.Num / FractNumber2.Denom;
                    Fraction result = FractNumber1.Plus(FractNumber2);
                    Console.WriteLine("Результат сложения: " + result.ToString());
                    result = FractNumber1.Minus(FractNumber2);
                    Console.WriteLine("Результат вычитания: " + result.ToString());
                    result = FractNumber1.Multi(FractNumber2);
                    Console.WriteLine("Результат умножения: " + result.ToString());
                    result = FractNumber1.Division(FractNumber2);
                    Console.WriteLine(result.ToString());
                }
                catch
                {
                    Console.WriteLine("Знаменатель дроби не может быть равным 0");
                }
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
                int taskNo = 0;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Введите номер задачи. Для завершения работы приложения введите 0.");
                    Console.WriteLine("1.Комплексные числа.");
                    Console.WriteLine("2.Cумму всех нечётных положительных чисел. TryParse.");
                    Console.WriteLine("3.Арифметические действия с дробями. Класс ArgumentException.");
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
}