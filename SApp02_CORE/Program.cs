using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp02_CORE
{
    class Program
    {

        static void PrintDir(DirectoryInfo dir, string indent, bool lastDirectory)
        {
            Console.Write(indent);
            if (lastDirectory)
            {
                Console.Write("└─");
                indent += "  "; // indent = indent + "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "│ ";
            }

            Console.WriteLine(dir.Name);


            FileInfo[] subFiles = dir.GetFiles();

            DirectoryInfo[] subDirs = dir.GetDirectories();
            for (int i = 0; i < subDirs.Length; i++)
            {
                PrintDir(subDirs[i], indent, i == subDirs.Length - 1);
            }

        }

        static void Main(string[] args)
        {
            // Directory, File, FileInfo, DirectoryInfo

            DirectoryInfo directoryInfo1 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory); // - работает
            DirectoryInfo directoryInfo2 = new DirectoryInfo(Environment.CurrentDirectory); // - работает вместе с названием ЕХЕ
                //DirectoryInfo directoryInfo3 = new DirectoryInfo(System.Net.Mime.MediaTypeNames.Application.ExecutablePath);
            //DirectoryInfo directoryInfo4 = new DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly().Location); //- работает только в Visual studio
                //DirectoryInfo directoryInfo5 = new DirectoryInfo(System.Net.Mime.MediaTypeNames.Application.StartupPath);

            Console.WriteLine($"FullName {directoryInfo2.FullName}");
            

            Console.WriteLine($"FullName {directoryInfo1.FullName}");
            Console.WriteLine($"Name {directoryInfo1.Name}");
            Console.WriteLine($"Parent {directoryInfo1.Parent}");
            Console.WriteLine($"CreationTime {directoryInfo1.CreationTime}");
            Console.WriteLine($"Root {directoryInfo1.Root}");

            //Console.Clear();

            PrintDir(directoryInfo1, "", true);

            Console.ReadKey();
        }
    }
}
