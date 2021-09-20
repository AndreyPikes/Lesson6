using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_Task3
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;        
        public string department;
        public int studyYear;
        public int group;
        public string city;
        public int Age { get; private set; }

        /// <summary>
        /// Создаем конструктор
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="university">Институт</param>
        /// <param name="faculty">Факультет</param>
        /// <param name="department">Департамент</param>
        /// <param name="age">Возраст</param>
        /// <param name="studyYear">Курс</param>
        /// <param name="group">Группа</param>
        /// <param name="city">Город</param>
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int studyYear, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.Age = age;
            this.studyYear = studyYear;
            this.group = group;
            this.city = city;
        }
    }
    class Program
    {
        static int StudentNameSort(Student st1, Student st2)         // Создаем метод для сравнения для экземпляров
        {
            return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки
        }
        static int StudentAgeSort(Student st1, Student st2)         // Создаем метод для сравнения для экземпляров
        {
            return st1.Age.CompareTo(st2.Age);          // Сравниваем две строки
        }
        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            int studentsOf5and6year = 0;
            List<Student> list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[7]) < 3) bakalavr++; else magistr++;
                    if (int.Parse(s[6]) >= 5) studentsOf5and6year++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(StudentAgeSort));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            Console.WriteLine("Студентов 5 и 6 курса:{0}", studentsOf5and6year);

            foreach (var v in list) Console.WriteLine($"Имя: {v.firstName, 10}, Возраст: {v.Age}");
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }


}
