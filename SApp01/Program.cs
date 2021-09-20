using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp01
{

    delegate double DoOperation(double x, double y);
    delegate void DoProcess(int x);

    class Program
    {

        public static  void DoProcess1(int x)
        {
            Console.WriteLine($"Do process1 ... {x}");
        }

        public static void DoProcess2(int x)
        {
            Console.WriteLine($"Do process2 ... {x}");
        }

        public static void DoProcess3(int x)
        {
            Console.WriteLine($"Do process3 ... {x}");
        }


        public static double Plus(double a, double b)
        {
            Console.Write($"{a} + {b}");
            return a + b;
        }

        private static double Minus(double a, double b)
        {
            Console.Write($"{a} - {b}");
            return a - b;
        }

        public static void Process(DoOperation doOperation, double param1, double param2)
        {
            Console.Write($" = {doOperation(param1, param2)}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            DoOperation doOperation01 = Plus;
            double r = doOperation01(10, 5);
            Console.WriteLine($" = {r}");

            DoOperation doOperation02 = Minus;
            Process(doOperation02, 10, 11);

            Process(Minus, 10, 11);

            DoOperation multiOperation = delegate (double a, double b)
            {
                Console.Write($"{a} * {b}");
                return a * b;
            };

            Process(delegate (double a, double b)
            {
                Console.Write($"{a} * {b}");
                return a * b;
            }, 5, 5);

            ReportProcess reportProcess = new ReportProcess();

            DoProcess doProcess = DoProcess1;
            doProcess += DoProcess2;
            doProcess += DoProcess3;
            doProcess += reportProcess.ProcessReport;

            doProcess.Invoke(20);


            Console.ReadKey();
        }
    }
}
