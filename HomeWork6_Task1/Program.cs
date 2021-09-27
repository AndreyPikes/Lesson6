using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_Task1
{
    // Описываем делегат. В делегате описывается сигнатура методов, на
    // которые он сможет ссылаться в дальнейшем (хранить в себе)
    public delegate double Fun(double a, double x);

    class Program
    {
        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("------- X ------- A ------- Y ----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", x, a, F(a, x));
                x += 1;
            }
            Console.WriteLine("----------------------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double a, double x)
        {
            return x * x * x;
        }

        public static double Sin(double a, double x)
        {
            return a * Math.Sin(x);
        }

        static void Main()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), 1, -2, 2);
            Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, 1, -2, 2);
            Console.WriteLine("Таблица функции a*Sin:");
            Table(Sin, 10, -2, 2);
            Console.WriteLine("Таблица функции x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double a, double x) { return x * x; }, 10, 0, 3);
            Console.WriteLine("Таблица функции a*x^2:");
            // Использование лямбда-выражения
            Table((double a, double x) => { return a * Math.Pow(x, 2); }, 10, -2, 2);

            Console.ReadKey();
        }
    }
}


