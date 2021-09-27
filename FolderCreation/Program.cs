using System;
using System.Collections.Generic;
using System.IO;

namespace FolderCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Создание внутренних папок объектов. Фотограф Щукин Андрей. www.instavr.ru";

            DirectoryInfo baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine($"Базовая директория: \"{baseDirectory.FullName}\"");            

            List<string> foldersCreatedNames = new List<string>() { "3D", "Info", "Pano" };

            DirectoryInfo[] subDirs = baseDirectory.GetDirectories();

            if (subDirs.Length == 0) Console.WriteLine("Запустите эту программу среди имеющихся папок!");
            else
            {
                for (int i = 0; i < subDirs.Length; i++)
                {
                    foreach (var folder in foldersCreatedNames)
                    {
                        subDirs[i].CreateSubdirectory($"{subDirs[i].Name} {folder}");
                        Console.WriteLine($"В папке \"{subDirs[i].Name}\" создана папка \"{folder}\"");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
