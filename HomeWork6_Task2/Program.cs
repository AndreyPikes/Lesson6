using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork6_Task2
{
    delegate double Function(double x); 
    class Program
    {
        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static double F2(double x)
        {
            return x * x * x - 20 * x + 10;
        }
        public static double F3(double x)
        {
            return x * x * x - 50 * x * x + 10 * x;
        }
        public static void SaveFunc(Function func, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(func(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static List<double> Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            List<double> result = new List<double>();
            double current = new double();

            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                current = bw.ReadDouble();
                result.Add(current);
                if (current < min) min = current;
            }
            bw.Close();
            fs.Close();
            return result;
        }

        static void Process(Function func)
        {
            SaveFunc(func,"data.bin", -100, 100, 0.5);
            double min = 0;

            List<double> result = Load("data.bin", out min);

            foreach (var e in result)
            {
                Console.WriteLine($"Значение функции = {e}");
            }
            Console.WriteLine($"Минимум значений функции = {min}");
        }

        static void Main(string[] args)
        {
            int answer;
            do
            {
                Console.WriteLine("Введите номер выбранной фунцкии (1 - 3). Чтобы выйти, нажмите \"0\"");
                
                if (int.TryParse(Console.ReadLine(), out answer) && answer > 0 && answer <= 3)
                {
                    switch (answer)
                    {
                        case 1: Console.WriteLine("Выбрано 1. Функция x * x - 50 * x + 10");
                            Process(F1);
                            break;
                        case 2:
                            Console.WriteLine("Выбрано 2. Функция x * x * x - 20 * x + 10");
                            Process(F2);
                            break;
                        case 3:
                            Console.WriteLine("Выбрано 3. Функция x * x * x - 50 * x * x + 10 * x");
                            Process(F3);
                            break;
                    }
                }
            } 
            while (answer != 0);
            Console.ReadKey();
        }
    }
}

