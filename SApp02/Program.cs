using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp02
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

            DirectoryInfo directoryInfo = new DirectoryInfo("F:\\Старые фото 201 ГБ");

            Console.WriteLine($"FullName {directoryInfo.FullName}");
            Console.WriteLine($"Name {directoryInfo.Name}");
            Console.WriteLine($"Parent {directoryInfo.Parent}");
            Console.WriteLine($"CreationTime {directoryInfo.CreationTime}");
            Console.WriteLine($"Root {directoryInfo.Root}");

            Console.Clear();

            PrintDir(directoryInfo, "", true);

            Console.ReadKey();
        }
    }
}
