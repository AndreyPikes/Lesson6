using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp04
{

    class User : IComparable<User>
    {
        public string Name { get; set; } // автосвойство

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public int CompareTo(User other)
        {
            return Surname.CompareTo(other.Surname);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList users1 = new ArrayList();

            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "UserList.txt");

            while (!reader.EndOfStream)
            {
                string[] words = reader.ReadLine().Split(' ');
                User user = new User();
                user.Name = words[1];
                user.Surname = words[0];
                user.Birthday = Convert.ToDateTime(words[2]);
                users1.Add(user);
            }

            reader.Close();

            users1.Add(1);
            users1.Add("Hello");
            users1.Add(true);

            foreach (object user in users1)
            {
                if (user is User)
                {
                    Console.WriteLine($"{(user as User).Surname} {(user as User).Name} {(user as User).Birthday.ToShortDateString()}");
                }
            }


            List<User> users02 = new List<User>();

            //users02.Add(1);
            //users02.Add("Hello");
            //users02.Add(true);

            Console.WriteLine();

            StreamReader reader02 = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "UserList.txt");

            while (!reader02.EndOfStream)
            {
                string[] words = reader02.ReadLine().Split(' ');
                User user = new User();
                user.Name = words[1];
                user.Surname = words[0];
                user.Birthday = Convert.ToDateTime(words[2]);
                users02.Add(user);
            }

            reader.Close();

            foreach (User user in users02)
            {
                Console.WriteLine($"{user.Surname} {user.Name} {user.Birthday.ToShortDateString()}");
            }

            users02.Sort();

            Console.WriteLine();

            foreach (User user in users02)
            {
                Console.WriteLine($"{user.Surname} {user.Name} {user.Birthday.ToShortDateString()}");
            }

            Console.ReadKey();


        }
    }
}
