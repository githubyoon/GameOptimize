using System;
using System.IO;

namespace GameOptimize
{
    internal class Program
    {
        
        private static string GOdir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "GameOptimize"
        );

        static void init()
        {
                Directory.CreateDirectory(GOdir);
        }

        public static void Main(string[] args)
        {
            init();
            Console.WriteLine(GOdir);
        }
    }
}